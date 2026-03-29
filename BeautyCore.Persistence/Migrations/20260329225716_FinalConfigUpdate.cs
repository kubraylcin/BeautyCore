using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FinalConfigUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Promotions_PromotionId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Staffs_StaffId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Appointments_AppointmentId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Branches_BranchId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceStaff_Services_ServicesId",
                table: "ServiceStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceStaff_Staffs_StaffsId",
                table: "ServiceStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Branches_BranchId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_ImageFiles_ProfilePictureId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffWorkingHours_Staffs_StaffId",
                table: "StaffWorkingHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceStaff",
                table: "ServiceStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "StaffMembers");

            migrationBuilder.RenameTable(
                name: "ServiceStaff",
                newName: "StaffServices");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Paynets");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_ProfilePictureId",
                table: "StaffMembers",
                newName: "IX_StaffMembers_ProfilePictureId");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_BranchId",
                table: "StaffMembers",
                newName: "IX_StaffMembers_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceStaff_StaffsId",
                table: "StaffServices",
                newName: "IX_StaffServices_StaffsId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_AppointmentId",
                table: "Paynets",
                newName: "IX_Paynets_AppointmentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Notifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "StaffMembers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "StaffMembers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "StaffMembers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionReference",
                table: "Paynets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Paynets",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "TRY",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffMembers",
                table: "StaffMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffServices",
                table: "StaffServices",
                columns: new[] { "ServicesId", "StaffsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paynets",
                table: "Paynets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Promotions_PromotionId",
                table: "Appointments",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_StaffMembers_StaffId",
                table: "Appointments",
                column: "StaffId",
                principalTable: "StaffMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Paynets_Appointments_AppointmentId",
                table: "Paynets",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Branches_BranchId",
                table: "Promotions",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffMembers_Branches_BranchId",
                table: "StaffMembers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffMembers_ImageFiles_ProfilePictureId",
                table: "StaffMembers",
                column: "ProfilePictureId",
                principalTable: "ImageFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffServices_Services_ServicesId",
                table: "StaffServices",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffServices_StaffMembers_StaffsId",
                table: "StaffServices",
                column: "StaffsId",
                principalTable: "StaffMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffWorkingHours_StaffMembers_StaffId",
                table: "StaffWorkingHours",
                column: "StaffId",
                principalTable: "StaffMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Promotions_PromotionId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_StaffMembers_StaffId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Paynets_Appointments_AppointmentId",
                table: "Paynets");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Branches_BranchId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffMembers_Branches_BranchId",
                table: "StaffMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffMembers_ImageFiles_ProfilePictureId",
                table: "StaffMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffServices_Services_ServicesId",
                table: "StaffServices");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffServices_StaffMembers_StaffsId",
                table: "StaffServices");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffWorkingHours_StaffMembers_StaffId",
                table: "StaffWorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Email",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffServices",
                table: "StaffServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffMembers",
                table: "StaffMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paynets",
                table: "Paynets");

            migrationBuilder.RenameTable(
                name: "StaffServices",
                newName: "ServiceStaff");

            migrationBuilder.RenameTable(
                name: "StaffMembers",
                newName: "Staffs");

            migrationBuilder.RenameTable(
                name: "Paynets",
                newName: "Payments");

            migrationBuilder.RenameIndex(
                name: "IX_StaffServices_StaffsId",
                table: "ServiceStaff",
                newName: "IX_ServiceStaff_StaffsId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffMembers_ProfilePictureId",
                table: "Staffs",
                newName: "IX_Staffs_ProfilePictureId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffMembers_BranchId",
                table: "Staffs",
                newName: "IX_Staffs_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Paynets_AppointmentId",
                table: "Payments",
                newName: "IX_Payments_AppointmentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TransactionReference",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldDefaultValue: "TRY");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceStaff",
                table: "ServiceStaff",
                columns: new[] { "ServicesId", "StaffsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Promotions_PromotionId",
                table: "Appointments",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Staffs_StaffId",
                table: "Appointments",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Appointments_AppointmentId",
                table: "Payments",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Branches_BranchId",
                table: "Promotions",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceStaff_Services_ServicesId",
                table: "ServiceStaff",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceStaff_Staffs_StaffsId",
                table: "ServiceStaff",
                column: "StaffsId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Branches_BranchId",
                table: "Staffs",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_ImageFiles_ProfilePictureId",
                table: "Staffs",
                column: "ProfilePictureId",
                principalTable: "ImageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffWorkingHours_Staffs_StaffId",
                table: "StaffWorkingHours",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
