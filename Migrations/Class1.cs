using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations
{
    [Migration(1)]
    public class Class1 : Migration
    {
        public override void Up()
        {
            Create.Table("orders").WithColumn("id").AsInt32()
                                 .WithColumn("amount_pay").AsDouble()
                                 .WithColumn("date").AsDateTime()
                                 .WithColumn("status").AsInt32()
                                 .WithColumn("id_user").AsInt32()
                                 .WithColumn("id_material").AsInt32()
                                 .WithColumn("deleted").AsInt32();

            


        }

        public override void Down()
        {

        }
    }
}
