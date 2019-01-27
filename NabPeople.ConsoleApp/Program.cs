using NabPeople.Dal.Repository;
using System;
using NabPeople.Dal.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using NabPeople.Reader;

namespace NabPeople.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Get the report list.
                PeopleReportCatsSimple report = new PeopleReportCatsSimple();
                List<ReportRow> reportList = await report.GetReport();

                // Display the report.
                foreach (ReportRow reportRow in reportList)
                {
                    Console.WriteLine(reportRow.RowContent);
                }
            }
            catch (PeopleReaderException ex)
            {
                Console.WriteLine("NabPeople application : " + ex.Message);
                //TODO : Add logging here.
            }
            catch (PeopleReportException ex)
            {
                Console.WriteLine("NabPeople application : " + ex.Message);
                //TODO : Add logging here.
            }
            catch (Exception)
            {
                Console.WriteLine("There has been a general exception running the NabPeople application.");
                //TODO : Add logging here.
            }

            Console.ReadLine();
        }
    }
}
