﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.DAL_EF.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Users",
                newName: "test");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "test",
                table: "Users",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "Users",
                newName: "Name");
        }
    }
}
