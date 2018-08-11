using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Produkty.Repository.Migrations
{
    public partial class SeedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Id,CategoryId,Description,Name,Price) VALUES ('1e0231b3-a0aa-47a7-a845-3283a1732a12','3e0231b3-a0aa-47a7-a845-3283a1732a12','Do jedzenia!','Chleb','1.99')");
            migrationBuilder.Sql("INSERT INTO Products (Id,CategoryId,Description,Name,Price) VALUES ('1e0231b3-a0aa-47a7-a845-3283a1732121','3e0231b3-a0aa-47a7-a845-3283a1732a13','Do jedzenia!','Jogurt Naturalny 200ml',1.59)");
            migrationBuilder.Sql("INSERT INTO Products (Id,CategoryId,Description,Name,Price) VALUES ('1e0231b3-a0aa-47a7-a845-3283a1732321','3e0231b3-a0aa-47a7-a845-3283a1712a16','Do Picia, najlepiej smakuje schłodzony.','Piwo Tyskie 500ml but.',2.59)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products WHERE Id='1e0231b3-a0aa-47a7-a845-3283a1732a12' OR id='1e0231b3-a0aa-47a7-a845-3283a1732121' OR id ='1e0231b3-a0aa-47a7-a845-3283a1732321'");
        }
    }
}
