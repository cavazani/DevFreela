using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Core 
{
    public class ProjectTests 
    {
        [Fact]
        public void ProjectIsCreated_Strat_Success() 
        {
            // Arrange
            var project = new Project("Projeto A", "Descriação do Projeto", 1, 2, 10000);

            // Act
            project.Start();

            // Assert
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

            Assert.True(project.Status == ProjectStatusEnum.InProgress);
            Assert.False(project.StartedAt is null);
        }
    }
}
