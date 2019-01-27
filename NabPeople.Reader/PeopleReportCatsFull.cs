using System;
using System.Collections.Generic;
using System.Text;
using NabPeople.Dal.Domain;

namespace NabPeople.Reader
{
    // Not implemented as not a part of the requirement.
    // Included to demonstrate extensibility of report design.
    public class PeopleReportCatsFull : PeopleReportBase
    {
        public override string ReportName => throw new NotImplementedException();

        public override List<ReportRow> GetReportRowsForPeople(List<Person> people)
        {
            throw new NotImplementedException();
        }

        protected override List<ReportRow> GetContent(List<Person> people)
        {
            throw new NotImplementedException();
        }

        protected override ReportRow GetFooter()
        {
            throw new NotImplementedException();
        }

        protected override ReportRow GetHeading()
        {
            throw new NotImplementedException();
        }
    }
}
