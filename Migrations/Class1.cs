using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations
{
    [Migration(4)]
    public class Class1 : Migration
    {
        public override void Up()
        {
            Create.Table("videos").WithColumn("id").AsInt32()
                .WithColumn("format").AsString().WithColumn("id_lesson").AsInt32().WithColumn("deleted").AsBoolean();
        }

        public override void Down()
        {

        }
    }
}
