using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Claims.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        -- Seed data for ClaimType
        INSERT INTO ClaimTypes ( Name)
        VALUES
            ('Type 1'),
            ('Type 2'),
            ('Type 3');

        -- Seed data for Company
        INSERT INTO Companies ( Name, Address1, Address2, Address3, Postcode, Country, Active, InsuranceEndDate)
        VALUES
            ( 'Company A', 'Address A1', 'Address A2', 'Address A3', '12345', 'Country A', 1, '2023-12-31'),
            ( 'Company B', 'Address B1', 'Address B2', 'Address B3', '54321', 'Country B', 0, '2024-06-30'),
            ( 'Company C', 'Address C1', 'Address C2', 'Address C3', '67890', 'Country C', 1, '2023-09-15');

        -- Seed data for Claims
        INSERT INTO Claims (UCR, CompanyId, ClaimDate, LossDate, AssuredName, [IncurredLoss], Closed, ClaimTypeId)
        VALUES
            ('UCR001', 1, '2022-01-15', '2022-01-10', 'Assured 1', 1500.50, 0, 1),
            ('UCR002', 2, '2022-02-20', '2022-02-18', 'Assured 2', 2000.75, 1, 2),
            ('UCR003', 3, '2022-03-25', '2022-03-22', 'Assured 3', 3000.25, 0, 3);
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Claims");
            migrationBuilder.Sql("DELETE FROM Company");
            migrationBuilder.Sql("DELETE FROM ClaimType");

        }
    }
}
