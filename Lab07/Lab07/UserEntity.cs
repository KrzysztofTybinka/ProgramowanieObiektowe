using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Lab07
{
    /*
     
CREATE TABLE [dbo].[UserEntity] (
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[Name] NCHAR(50) NOT NULL,
	[Role] NCHAR(20) NOT NULL,
	[CreatedAt] DATETIME NOT NULL,
	[RemovedAt] DATETIME,
	PRIMARY KEY ([Id])
);
     
     
     */


    [Table(Name = "UserEntity")]
    public class UserEntity
    {
        [Column(IsPrimaryKey = true, Name = "Id", IsDbGenerated=true)]
        public long Id { get; set; }        

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Role")]
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT

        [Column(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Column(Name = "RemovedAt")]
        public DateTime? RemovedAt { get; set; }
    }
}
