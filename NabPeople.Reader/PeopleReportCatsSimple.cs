using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NabPeople.Dal.Domain;
using NabPeople.Dal.Repository;

namespace NabPeople.Reader
{
    public class PeopleReportCatsSimple : PeopleReportBase
    {
        private const string fiveSpaces = "     ";
        public override string ReportName { get => "NAB people report : cat names."; }

        public async Task<List<ReportRow>> GetReport()
        {
            PeopleReader pr = new PeopleReader();
            List<Person> people = await pr.GetPeopleList();
            return GetReportRowsForPeople(people);
        }

        /// <summary>
        /// Adds row contents to the report list.
        /// Returns a list of report rows.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public override List<ReportRow> GetReportRowsForPeople(List<Person> people)
        {
            if (people == null)
            {
                throw new PeopleReportException("People list cannot be null.");
            }

            List<ReportRow> reportList = new List<ReportRow>();

            try
            {
                // If the people parameter is null or contains no entries then return the no entry report.
                if (people == null)
                {
                    return this.NoEntryReport(reportList);
                }
                else
                if (people.Count == 0)
                {
                    return this.NoEntryReport(reportList);
                }

                this.AddBlankRows(reportList, 2);
                reportList.Add(this.GetHeading());

                this.AddBlankRows(reportList, 1);
                // Add the content.
                List<ReportRow> contentRows = this.GetContent(people);
                if (contentRows.Count == 0)
                {
                    // If there is no content then return the no entry report.
                    return this.NoEntryReport(reportList);
                }
                else
                {
                    reportList.AddRange(contentRows);
                }

                this.AddBlankRows(reportList, 1);
                reportList.Add(this.GetFooter());

                return reportList;
            }
            catch (Exception ex)
            {
                throw new PeopleReportException("Error in report generation.", ex);
            }

        }

        protected override ReportRow GetHeading()
        {
            return new ReportRow()
            {
                RowType = ReportRowType.Heading,
                RowContent = this.ReportName
            };
        }

        protected override List<ReportRow> GetContent(List<Person> people)
        {
            List<ReportRow> contentResult = new List<ReportRow>();

            List<ReportRow> maleResult = GetGenderContentGroup(people, Gender.Male);
            contentResult.AddRange(maleResult);

            List<ReportRow> femaleResult = GetGenderContentGroup(people, Gender.Female);
            contentResult.AddRange(femaleResult);

            return contentResult;
        }

        private List<ReportRow> GetGenderContentGroup(List<Person> people, Gender gender)
        {
            List<ReportRow> result = new List<ReportRow>();
            List<ReportRow> subGroupContentResult = new List<ReportRow>();
            result.Add(new ReportRow() { RowType=ReportRowType.ContentGroup, RowContent=gender.ToString() });
            List<Person> peopleByGender = people.Where(x => x.Gender == gender).ToList();

            foreach (Person person in peopleByGender)
            {
                if (person.Pets != null)
                {
                    foreach (Pet pet in person.Pets)
                    {
                        if (pet.PetType == PetType.Cat)
                        {
                            ReportRow row = new ReportRow()
                            {
                                RowType = ReportRowType.Content,
                                RowContent = fiveSpaces + pet.Name
                            };
                            subGroupContentResult.Add(row);
                        }
                    }
                }
            }

            // Set the content order.
            subGroupContentResult = subGroupContentResult.OrderBy(x => x.RowContent).ToList();
            result.AddRange(subGroupContentResult);

            return result;
        }


        protected override ReportRow GetFooter()
        {
            return new ReportRow()
            {
                RowType = ReportRowType.Footer,
                RowContent = "Report run : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
            };
        }


    }
}
