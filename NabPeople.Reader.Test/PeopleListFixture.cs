using NabPeople.Dal.Domain;
using System.Collections.Generic;

namespace NabPeople.Reader.Tests
{
    public class PeopleListFixture
    {
        public string ValidJsonData { get; set; }
        public string InvalidJsonData { get; set; }
        public List<Person> TestPeople { get; set; }

        public PeopleListFixture()
        {
            ValidJsonData = TestDataJsonValid();
            InvalidJsonData = TestDataJsonInvalid();
            TestPeople = GetPeopleList();
        }

        public List<Person> GetPeopleList()
        {
            List<Person> peopleList = new List<Person>();
            peopleList.Add(
                new Person() {
                    Age = 30,
                    Gender = Gender.Male,
                    Name = "TestName1",
                    Pets = new List<Pet>() {
                    new Pet() { Name = "PetName1", PetType = PetType.Cat },
                    new Pet() { Name="PetName2", PetType=PetType.Fish } }
                });
                
            peopleList.Add(
                new Person() {
                    Age=25,
                    Gender = Gender.Female,
                    Name="TestName2",
                    Pets = new List<Pet>() {
                        new Pet() { Name="PetName3", PetType=PetType.Cat },
                        new Pet(){ Name="PetName4", PetType=PetType.Cat },
                        new Pet(){ Name="PetName5", PetType=PetType.Dog} }
                });

            return peopleList;
        }

        private string TestDataJsonInvalid()
        {
            // Age set to non-numeric.
            // This data is invalid and should throw an exception.
            return @"[{
                        'name': 'N1',
                        'gender': 'Male',
                        'age': 'ZZZ',
                        'pets': [
                          {
                            'name': 'P1',
                            'type': 'Cat'
                          },
                          {
                            'name': 'P2',
                            'type': 'Dog'
                          }
                        ]
                      }]";
        }

        private string TestDataJsonValid()
        {
            return @"[
                      {
                        'name': 'N1',
                        'gender': 'Male',
                        'age': 30,
                        'pets': [
                          {
                            'name': 'P1',
                            'type': 'Cat'
                          },
                          {
                            'name': 'P2',
                            'type': 'Dog'
                          }
                        ]
                      },
                      {
                        'name': 'N2',
                        'gender': 'Female',
                        'age': 30,
                        'pets': [
                          {
                            'name': 'P3',
                            'type': 'Cat'
                          },
                          {
                            'name': 'P4',
                            'type': 'Dog'
                          }
                        ]
                      },
                      {
                        'name': 'N3',
                        'gender': 'Male',
                        'age': 30,
                        'pets': [
                          {
                            'name': 'P5',
                            'type': 'Cat'
                          },
                          {
                            'name': 'P6',
                            'type': 'Dog'
                          }
                        ]
                      }
                   ]";


        }

    }
}
