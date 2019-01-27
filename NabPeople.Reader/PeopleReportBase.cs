using NabPeople.Dal.Domain;
using System.Collections.Generic;

namespace NabPeople.Reader
{
    public abstract class PeopleReportBase
    {
        public abstract string ReportName { get;}
        public abstract List<ReportRow> GetReportRowsForPeople(List<Person> people);

        protected List<ReportRow> NoEntryReport(List<ReportRow> reportList)
        {
            reportList.Clear();
            reportList.Add(new ReportRow() { RowType = ReportRowType.NoEntries, RowContent = "Report contains no entries." });
            return reportList;
        }

        protected List<ReportRow> AddBlankRows(List<ReportRow> reportList, int blankRowCount)
        {
            for (int i = 1; i <= blankRowCount; i++)
            {
                reportList.Add(new ReportRow() { RowType = ReportRowType.Blank, RowContent = string.Empty });
            }
            
            return reportList;
        }

        protected abstract List<ReportRow> GetContent(List<Person> people);
        protected abstract ReportRow GetHeading();
        protected abstract ReportRow GetFooter();
    }
}
