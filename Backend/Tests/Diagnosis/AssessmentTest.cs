using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;
using Xunit;

namespace Tests.Diagnosis
{
    public class AssessmentTest
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public AssessmentTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = AssessmentTest.db; Foreign Keys=False").Options;
            Seed();
        }
        [Fact]
        public void SearchByDiagnosisIdShouldReturnResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repository = new AssessmentRepository(context);
                var patient = repository.SearchByDiagnosisId(1);

                Assert.NotNull(patient);
            }
        }
        [Fact]
        public void SearchByDiagnosisIdShouldThrowNullExceptionOnNoResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repository = new AssessmentRepository(context);

                                    Assert.Empty(repository.SearchByDiagnosisId(-1));

            }
        }
        [Fact]
        public void GetbyIdShouldReturnAssessmentId()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repository = new AssessmentRepository(context);
                var assessment = repository.GetById(1);

                Assert.Equal(1, assessment.Id);
            }
        }

        // [Fact]
        // public void GetPatientAssessmentShouldThrowException()
        // {
        //      using ( var context = new CloudCureDbContext(_options))
        //         {
        //             IAssessmentRepository repository = new AssessmentRepository(context);
                    
        //                                 Assert.Empty(repository.SearchByDiagnosisId(-1));

        //         }
        // }
        
        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Assessments.AddRange(
                    new Assessment
                    {
                        DiagnosisId = 1,
                        PainAssessment = "asdfas",
                        PainScale = 2,
                        ChiefComplaint = "dfdssdf",
                        HistoryOfPresentIllness = "dssdfs",


                    },
                            new Assessment
                            {
                                DiagnosisId = 2,
                                PainAssessment = "asdfas",
                                PainScale = 2,
                                ChiefComplaint = "dfdssdf",
                                HistoryOfPresentIllness = "dssdfs",
                                


                            });


                context.SaveChanges();

            }
        }
    }
}
