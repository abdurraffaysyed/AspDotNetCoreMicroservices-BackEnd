using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using ProductsMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsMicroservice.MigrationScript
{
    [DbContext(typeof(AppDbContext))]
    [Migration("MyCustomMigrationsp")]
    public partial class ProductsMigrationScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Create table manage_orders5575(" +
                "product_id varchar(200) primary key," +
                "foreign key (product_id) references products(productid));");
            //migrationBuilder.CreateTable(
            //    name: "manage_orders41",
            //    columns: table => new
            //    {
            //        product_id = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("pk_manage_orders", x => new {x.product_id });

            //        //table.ForeignKey(
            //        //    name: "fk_manage_orders_products_product_id",
            //        //    column: x => x.product_id,
            //        //    principalTable: "products",
            //        //    principalColumn: "productid",
            //        //    onDelete: ReferentialAction.Restrict); // Update this based on your needs
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manage_orders");
        }
    }
}
