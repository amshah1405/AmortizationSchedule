using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MortgageDetail",
                columns: table => new
                {
                    mortgageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loanAmount = table.Column<double>(type: "float", nullable: false),
                    annualInterestRate = table.Column<double>(type: "float", nullable: false),
                    loanTerm = table.Column<int>(type: "int", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageDetail", x => x.mortgageID);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyPaymentDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mortageId = table.Column<int>(type: "int", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    remainingBalance = table.Column<double>(type: "float", nullable: false),
                    principalAmt = table.Column<double>(type: "float", nullable: false),
                    monthlyInterest = table.Column<double>(type: "float", nullable: false),
                    monthlyPayment = table.Column<double>(type: "float", nullable: false),
                    totalInterest = table.Column<double>(type: "float", nullable: false),
                    totalPaid = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPaymentDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_MonthlyPaymentDetails_MortgageDetail_mortageId",
                        column: x => x.mortageId,
                        principalTable: "MortgageDetail",
                        principalColumn: "mortgageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPaymentDetails_mortageId",
                table: "MonthlyPaymentDetails",
                column: "mortageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyPaymentDetails");

            migrationBuilder.DropTable(
                name: "MortgageDetail");
        }
    }
}
