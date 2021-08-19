using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntityFrameWork.Migrations.ApplicationDb
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("7b854beb-335e-43b7-9228-de8a8e63b434"), "12999fff-2d70-4189-a0b4-dba99de21f4e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("17717cb9-1706-4c78-b89e-b0421a1d3958"), "d9dd4005-8138-42eb-941b-4cc2699eddd2", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("fa5e6060-a8e9-42d6-9603-ba9927360258"), "e0d5eaf8-56bd-4390-b009-181b8294c7b6", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17717cb9-1706-4c78-b89e-b0421a1d3958"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b854beb-335e-43b7-9228-de8a8e63b434"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fa5e6060-a8e9-42d6-9603-ba9927360258"));
        }
    }
}
