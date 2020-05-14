using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations
{
    [Migration(3)]
    public class Class1 : Migration
    {
        public override void Up()
        {
            Create.Table("subs").WithColumn("id").AsInt32()
                                .WithColumn("email").AsString()
                                .WithColumn("date").AsDateTime()
                                .WithColumn("deleted").AsBoolean();

        }

        public override void Down()
        {

        }
    }
}
