using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations
{
    [Migration(5)]
    public class Class1 : Migration
    {
        public override void Up()
        {
            Create.Column("url").OnTable("videos").AsString();
        }

        public override void Down()
        {

        }
    }
}
