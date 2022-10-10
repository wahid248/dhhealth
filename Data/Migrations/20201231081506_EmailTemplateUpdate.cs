using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EmailTemplateUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "CreatedOn" },
                values: new object[] { "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%;border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"userName\"></b> <p>This is to inform you that your query has been received. Our team will contact you soon.</p><br><p>Thank you!.</p><p>Dh Health Team</p><p>Visit our Website <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>. </div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", new DateTime(2020, 12, 31, 8, 15, 5, 838, DateTimeKind.Utc).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "CreatedOn" },
                values: new object[] { "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"UserName\"></b> <p id=\"Contact\"></p> <p id=\"Email\"></p><p id=\"message\"></p></div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", new DateTime(2020, 12, 31, 8, 15, 5, 838, DateTimeKind.Utc).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "CreatedOn" },
                values: new object[] { "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"userName\"></b><p>Thank you for your application and interest in Digital Healthcare Solutions (DH) as your Employer of Choice.</p><br> <p>At this stage, your patience is appreciated while our Talent Acquisition Team reviews your application. If you are shortlisted for further steps, you will be contacted by one of our professionals regarding further steps in the selection process.</p><br><br><p>Best Regards,</p><p>Digital Healthcare Solutions (DH)</p></div></div></body></html>", new DateTime(2020, 12, 31, 8, 15, 5, 838, DateTimeKind.Utc).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "CreatedOn" },
                values: new object[] { "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"applicantName\"></b> <p id=\"applicantContact\"></p><p id=\"applicantEmail\"></p></div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", new DateTime(2020, 12, 31, 8, 15, 5, 838, DateTimeKind.Utc).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "CreatedOn" },
                values: new object[] { "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b>Dear User, </b> <p>Thank you for your Subscribe.</p><p id=\"userEmail\"></p><p>Dh Health Team</p><p>Visit our Website <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>. </div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", new DateTime(2020, 12, 31, 8, 15, 5, 838, DateTimeKind.Utc).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "CreatedOn" },
                values: new object[] { "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; background: #ddd; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"userName\"></b> <p>This is to inform you that your query has been received. Our team will contact you soon.</p><br><p>Thank you!.</p><p>Dh Health Team</p><p>Visit our Website <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>. </div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", new DateTime(2020, 12, 21, 6, 50, 17, 978, DateTimeKind.Utc).AddTicks(8044) });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "CreatedOn" },
                values: new object[] { "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; background: #ddd; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"UserName\"></b> <p id=\"Contact\"></p> <p id=\"Email\"></p><p id=\"message\"></p></div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", new DateTime(2020, 12, 21, 6, 50, 17, 978, DateTimeKind.Utc).AddTicks(8044) });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "CreatedOn" },
                values: new object[] { "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; background: #ddd; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"userName\"></b> <p>This is to inform you that your response has been received. Our team will contact you soon.</p><br><p>Thank you!.</p><p>Dh Health Team</p><p>Visit our Website <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>. </div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", new DateTime(2020, 12, 21, 6, 50, 17, 978, DateTimeKind.Utc).AddTicks(8044) });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Body", "CreatedOn" },
                values: new object[] { "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; background: #ddd; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"applicantName\"></b> <p id=\"applicantContact\"></p><p id=\"applicantEmail\"></p></div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", new DateTime(2020, 12, 21, 6, 50, 17, 978, DateTimeKind.Utc).AddTicks(8044) });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Body", "CreatedOn" },
                values: new object[] { "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; background: #ddd; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b>Dear User, </b> <p>Thank you for your Subscribe.</p><p id=\"userEmail\"></p><p>Dh Health Team</p><p>Visit our Website <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>. </div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", new DateTime(2020, 12, 21, 6, 50, 17, 978, DateTimeKind.Utc).AddTicks(8044) });

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 21, 6, 50, 17, 961, DateTimeKind.Utc).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 21, 6, 50, 17, 961, DateTimeKind.Utc).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 21, 6, 50, 17, 961, DateTimeKind.Utc).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 21, 6, 50, 17, 961, DateTimeKind.Utc).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 21, 6, 50, 17, 961, DateTimeKind.Utc).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 21, 6, 50, 17, 961, DateTimeKind.Utc).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 21, 6, 50, 17, 961, DateTimeKind.Utc).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 21, 6, 50, 17, 961, DateTimeKind.Utc).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 21, 6, 50, 17, 961, DateTimeKind.Utc).AddTicks(2725));
        }
    }
}
