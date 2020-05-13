using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations
{
    [Migration(2)]
    public class Class1 : Migration
    {
        public override void Up()
        {
            Create.Column("nick_name").OnTable("persons").AsString();
            Create.Column("avatar").OnTable("persons").AsString();
            Create.Column("email").OnTable("persons").AsString();
            Create.Column("instagram").OnTable("persons").AsString();
            Create.Column("facebook").OnTable("persons").AsString();
            Create.Column("twitch").OnTable("persons").AsString();
            Create.Column("vk").OnTable("persons").AsString();




        }

        public override void Down()
        {

        }
    }
}
