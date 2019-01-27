using Xunit;
using Xunit.Abstractions;

using NabPeople.Dal.Domain;
using System.Collections.Generic;
using System.Linq;

namespace NabPeople.Reader.Tests
{
    public class GetReportShould : IClassFixture<PeopleListFixture>
    {
        ITestOutputHelper _output;
        PeopleReportCatsSimple _catReport;
        private readonly PeopleListFixture _peopleListFixture;
        public GetReportShould(PeopleListFixture peopleListFixture, ITestOutputHelper output)
        {
            _output = output;
            _peopleListFixture = peopleListFixture;
            _catReport = new PeopleReportCatsSimple();
        }

        [Fact]
        public void ForANullPeopleListReturnAPeopleReportException()
        {
            Assert.Throws<PeopleReportException>(() => _catReport.GetReportRowsForPeople(null));
        }

        [Fact]
        public void ReturnAReportListFromAValidPeopleList()
        {
            List<Person> testPeople = _peopleListFixture.TestPeople;
            List<ReportRow> reportRows = _catReport.GetReportRowsForPeople(testPeople);
            Assert.Equal(3, reportRows.Where(x=>x.RowType==ReportRowType.Content).ToList().Count);
        }

        [Fact]
        public void ReturnAReportHeadingInAValidReport()
        {
            List<Person> testPeople = _peopleListFixture.TestPeople;
            List<ReportRow> reportRows = _catReport.GetReportRowsForPeople(testPeople);
            Assert.Single(reportRows.Where(x => x.RowType == ReportRowType.Heading).ToList());
        }

        [Fact]
        public void ReturnAReportFooterInAValidReport()
        {
            List<Person> testPeople = _peopleListFixture.TestPeople;
            List<ReportRow> reportRows = _catReport.GetReportRowsForPeople(testPeople);
            Assert.Single(reportRows.Where(x => x.RowType == ReportRowType.Footer).ToList());
        }

        [Fact]
        public void ForAnEmptyPeopleListReturnAnEmptyReport()
        {
            List<ReportRow> reportRows = _catReport.GetReportRowsForPeople(new List<Person>());
            ReportRow oneRow = reportRows[0];
            _output.WriteLine("First row type : " + oneRow.RowType.ToString());

            Assert.Equal(ReportRowType.NoEntries, oneRow.RowType);
        }

        [Fact]
        void HaveAReportName()
        {
            Assert.NotNull(_catReport.ReportName);
        }

    }
}
