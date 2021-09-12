using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "ActorGender", "ActorName", "Actor_DOB" },
                values: new object[,]
                {
                    { 1, "Male", "VBN", new DateTime(2020, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Female", "SDF", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "ProducerId", "ProducerGender", "ProducerName", "Producer_CompanyName", "Producer_DOB" },
                values: new object[,]
                {
                    { 1, "Male", "Sam", "DF Productions", new DateTime(2020, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Female", "Jennifer", "KL Productions", new DateTime(2020, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "MovieName", "Movie_ReleaseDate", "ProducerId" },
                values: new object[] { 1, "BJKM", new DateTime(2021, 9, 11, 6, 38, 21, 303, DateTimeKind.Local).AddTicks(6185), 1 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "MovieName", "Movie_ReleaseDate", "ProducerId" },
                values: new object[] { 2, "YUIO", new DateTime(2020, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "ActorMovies",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ActorMovies",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "ProducerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "ProducerId",
                keyValue: 2);
        }
    }
}
