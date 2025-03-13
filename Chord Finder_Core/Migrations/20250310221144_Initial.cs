using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chord_Finder_Core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChordTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChordTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Frequency = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Chords",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ChordTypeID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Chords_ChordTypes_ChordTypeID",
                        column: x => x.ChordTypeID,
                        principalTable: "ChordTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChordTypes",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("46c55a1e-f908-421a-8079-8abba03f5869"), "A chord with a root, major second, and perfect fifth.", "Suspended Second" },
                    { new Guid("53fb45c9-8bb9-492e-9dac-258a460621cc"), "A chord with a root, major third, perfect fifth, and major seventh.", "Major Seventh" },
                    { new Guid("6c9ea46b-9625-4bef-bc6e-ee72da9ae732"), "A chord with a root, major third, and perfect fifth.", "Major" },
                    { new Guid("8d5f188c-d027-46d4-b4e8-5ed944bab598"), "A chord with a root, perfect fourth, and perfect fifth.", "Suspended Fourth" },
                    { new Guid("aabd075a-b201-473b-ad0f-d0d875ef1584"), "A chord with a root, minor third, and diminished fifth.", "Diminished" },
                    { new Guid("b289393b-d8e7-4db7-bf1d-d83caaf71704"), "A chord with a root, major third, and augmented fifth.", "Augmented" },
                    { new Guid("b449187c-cd70-4ca3-bd1d-3a5152d8b13c"), "A chord with a root, minor third, diminished fifth, and minor seventh.", "Half-Diminished" },
                    { new Guid("be08b4ae-f8f1-4518-bfec-f71b009a6006"), "A chord with a root, major third, perfect fifth, and minor seventh.", "Dominant Seventh" },
                    { new Guid("c7e1c758-87a8-4c00-9445-be26e069ec14"), "A chord with a root, minor third, diminished fifth, and diminished seventh.", "Diminished Seventh" },
                    { new Guid("ddd178b1-1421-4d3c-a21d-ce1bd63ee8c7"), "A chord with a root, minor third, perfect fifth, and minor seventh.", "Minor Seventh" },
                    { new Guid("fcc4ea0f-1545-4fa8-a759-a26d9cf24486"), "A chord with a root, minor third, and perfect fifth.", "Minor" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "ID", "Frequency", "Name" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000100000000"), 16.350000000000001, "C0" },
                    { new Guid("00000001-0000-0000-0000-000200000000"), 32.700000000000003, "C1" },
                    { new Guid("00000001-0000-0000-0000-000300000000"), 65.409999999999997, "C2" },
                    { new Guid("00000001-0000-0000-0000-000400000000"), 130.81, "C3" },
                    { new Guid("00000001-0000-0000-0000-000500000000"), 261.63, "C4" },
                    { new Guid("00000001-0000-0000-0000-000600000000"), 523.25, "C5" },
                    { new Guid("00000001-0000-0000-0000-000700000000"), 1046.5, "C6" },
                    { new Guid("00000001-0000-0000-0000-000800000000"), 2093.0, "C7" },
                    { new Guid("00000001-0000-0000-0000-000900000000"), 4186.0100000000002, "C8" },
                    { new Guid("00000002-0000-0000-0000-000100000000"), 17.32, "C#0/Db0" },
                    { new Guid("00000002-0000-0000-0000-000200000000"), 34.649999999999999, "C#1/Db1" },
                    { new Guid("00000002-0000-0000-0000-000300000000"), 69.299999999999997, "C#2/Db2" },
                    { new Guid("00000002-0000-0000-0000-000400000000"), 138.59, "C#3/Db3" },
                    { new Guid("00000002-0000-0000-0000-000500000000"), 277.18000000000001, "C#4/Db4" },
                    { new Guid("00000002-0000-0000-0000-000600000000"), 554.37, "C#5/Db5" },
                    { new Guid("00000002-0000-0000-0000-000700000000"), 1108.73, "C#6/Db6" },
                    { new Guid("00000002-0000-0000-0000-000800000000"), 2217.46, "C#7/Db7" },
                    { new Guid("00000002-0000-0000-0000-000900000000"), 4434.9200000000001, "C#8/Db8" },
                    { new Guid("00000003-0000-0000-0000-000100000000"), 18.350000000000001, "D0" },
                    { new Guid("00000003-0000-0000-0000-000200000000"), 36.710000000000001, "D1" },
                    { new Guid("00000003-0000-0000-0000-000300000000"), 73.420000000000002, "D2" },
                    { new Guid("00000003-0000-0000-0000-000400000000"), 146.83000000000001, "D3" },
                    { new Guid("00000003-0000-0000-0000-000500000000"), 293.66000000000003, "D4" },
                    { new Guid("00000003-0000-0000-0000-000600000000"), 587.33000000000004, "D5" },
                    { new Guid("00000003-0000-0000-0000-000700000000"), 1174.6600000000001, "D6" },
                    { new Guid("00000003-0000-0000-0000-000800000000"), 2349.3200000000002, "D7" },
                    { new Guid("00000003-0000-0000-0000-000900000000"), 4698.6300000000001, "D8" },
                    { new Guid("00000004-0000-0000-0000-000100000000"), 19.449999999999999, "D#0/Eb0" },
                    { new Guid("00000004-0000-0000-0000-000200000000"), 38.890000000000001, "D#1/Eb1" },
                    { new Guid("00000004-0000-0000-0000-000300000000"), 77.780000000000001, "D#2/Eb2" },
                    { new Guid("00000004-0000-0000-0000-000400000000"), 155.56, "D#3/Eb3" },
                    { new Guid("00000004-0000-0000-0000-000500000000"), 311.13, "D#4/Eb4" },
                    { new Guid("00000004-0000-0000-0000-000600000000"), 622.25, "D#5/Eb5" },
                    { new Guid("00000004-0000-0000-0000-000700000000"), 1244.51, "D#6/Eb6" },
                    { new Guid("00000004-0000-0000-0000-000800000000"), 2489.02, "D#7/Eb7" },
                    { new Guid("00000004-0000-0000-0000-000900000000"), 4978.0299999999997, "D#8/Eb8" },
                    { new Guid("00000005-0000-0000-0000-000100000000"), 20.600000000000001, "E0" },
                    { new Guid("00000005-0000-0000-0000-000200000000"), 41.200000000000003, "E1" },
                    { new Guid("00000005-0000-0000-0000-000300000000"), 82.409999999999997, "E2" },
                    { new Guid("00000005-0000-0000-0000-000400000000"), 164.81, "E3" },
                    { new Guid("00000005-0000-0000-0000-000500000000"), 329.63, "E4" },
                    { new Guid("00000005-0000-0000-0000-000600000000"), 659.25, "E5" },
                    { new Guid("00000005-0000-0000-0000-000700000000"), 1318.51, "E6" },
                    { new Guid("00000005-0000-0000-0000-000800000000"), 2637.02, "E7" },
                    { new Guid("00000005-0000-0000-0000-000900000000"), 5274.04, "E8" },
                    { new Guid("00000006-0000-0000-0000-000100000000"), 21.829999999999998, "F0" },
                    { new Guid("00000006-0000-0000-0000-000200000000"), 43.649999999999999, "F1" },
                    { new Guid("00000006-0000-0000-0000-000300000000"), 87.310000000000002, "F2" },
                    { new Guid("00000006-0000-0000-0000-000400000000"), 174.61000000000001, "F3" },
                    { new Guid("00000006-0000-0000-0000-000500000000"), 349.23000000000002, "F4" },
                    { new Guid("00000006-0000-0000-0000-000600000000"), 698.46000000000004, "F5" },
                    { new Guid("00000006-0000-0000-0000-000700000000"), 1396.9100000000001, "F6" },
                    { new Guid("00000006-0000-0000-0000-000800000000"), 2793.8299999999999, "F7" },
                    { new Guid("00000006-0000-0000-0000-000900000000"), 5587.6499999999996, "F8" },
                    { new Guid("00000007-0000-0000-0000-000100000000"), 23.120000000000001, "F#0/Gb0" },
                    { new Guid("00000007-0000-0000-0000-000200000000"), 46.25, "F#1/Gb1" },
                    { new Guid("00000007-0000-0000-0000-000300000000"), 92.5, "F#2/Gb2" },
                    { new Guid("00000007-0000-0000-0000-000400000000"), 185.0, "F#3/Gb3" },
                    { new Guid("00000007-0000-0000-0000-000500000000"), 369.99000000000001, "F#4/Gb4" },
                    { new Guid("00000007-0000-0000-0000-000600000000"), 739.99000000000001, "F#5/Gb5" },
                    { new Guid("00000007-0000-0000-0000-000700000000"), 1479.98, "F#6/Gb6" },
                    { new Guid("00000007-0000-0000-0000-000800000000"), 2959.96, "F#7/Gb7" },
                    { new Guid("00000007-0000-0000-0000-000900000000"), 5919.9099999999999, "F#8/Gb8" },
                    { new Guid("00000008-0000-0000-0000-000100000000"), 24.5, "G0" },
                    { new Guid("00000008-0000-0000-0000-000200000000"), 49.0, "G1" },
                    { new Guid("00000008-0000-0000-0000-000300000000"), 98.0, "G2" },
                    { new Guid("00000008-0000-0000-0000-000400000000"), 196.0, "G3" },
                    { new Guid("00000008-0000-0000-0000-000500000000"), 392.0, "G4" },
                    { new Guid("00000008-0000-0000-0000-000600000000"), 783.99000000000001, "G5" },
                    { new Guid("00000008-0000-0000-0000-000700000000"), 1567.98, "G6" },
                    { new Guid("00000008-0000-0000-0000-000800000000"), 3135.96, "G7" },
                    { new Guid("00000008-0000-0000-0000-000900000000"), 6271.9300000000003, "G8" },
                    { new Guid("00000009-0000-0000-0000-000100000000"), 25.960000000000001, "G#0/Ab0" },
                    { new Guid("00000009-0000-0000-0000-000200000000"), 51.909999999999997, "G#1/Ab1" },
                    { new Guid("00000009-0000-0000-0000-000300000000"), 103.83, "G#2/Ab2" },
                    { new Guid("00000009-0000-0000-0000-000400000000"), 207.65000000000001, "G#3/Ab3" },
                    { new Guid("00000009-0000-0000-0000-000500000000"), 415.30000000000001, "G#4/Ab4" },
                    { new Guid("00000009-0000-0000-0000-000600000000"), 830.61000000000001, "G#5/Ab5" },
                    { new Guid("00000009-0000-0000-0000-000700000000"), 1661.22, "G#6/Ab6" },
                    { new Guid("00000009-0000-0000-0000-000800000000"), 3322.4400000000001, "G#7/Ab7" },
                    { new Guid("00000009-0000-0000-0000-000900000000"), 6644.8800000000001, "G#8/Ab8" },
                    { new Guid("0000000a-0000-0000-0000-000100000000"), 27.5, "A0" },
                    { new Guid("0000000a-0000-0000-0000-000200000000"), 55.0, "A1" },
                    { new Guid("0000000a-0000-0000-0000-000300000000"), 110.0, "A2" },
                    { new Guid("0000000a-0000-0000-0000-000400000000"), 220.0, "A3" },
                    { new Guid("0000000a-0000-0000-0000-000500000000"), 440.0, "A4" },
                    { new Guid("0000000a-0000-0000-0000-000600000000"), 880.0, "A5" },
                    { new Guid("0000000a-0000-0000-0000-000700000000"), 1760.0, "A6" },
                    { new Guid("0000000a-0000-0000-0000-000800000000"), 3520.0, "A7" },
                    { new Guid("0000000a-0000-0000-0000-000900000000"), 7040.0, "A8" },
                    { new Guid("0000000b-0000-0000-0000-000100000000"), 29.140000000000001, "A#0/Bb0" },
                    { new Guid("0000000b-0000-0000-0000-000200000000"), 58.270000000000003, "A#1/Bb1" },
                    { new Guid("0000000b-0000-0000-0000-000300000000"), 116.54000000000001, "A#2/Bb2" },
                    { new Guid("0000000b-0000-0000-0000-000400000000"), 233.08000000000001, "A#3/Bb3" },
                    { new Guid("0000000b-0000-0000-0000-000500000000"), 466.16000000000003, "A#4/Bb4" },
                    { new Guid("0000000b-0000-0000-0000-000600000000"), 932.33000000000004, "A#5/Bb5" },
                    { new Guid("0000000b-0000-0000-0000-000700000000"), 1864.6600000000001, "A#6/Bb6" },
                    { new Guid("0000000b-0000-0000-0000-000800000000"), 3729.3099999999999, "A#7/Bb7" },
                    { new Guid("0000000b-0000-0000-0000-000900000000"), 7458.6199999999999, "A#8/Bb8" },
                    { new Guid("0000000c-0000-0000-0000-000100000000"), 30.870000000000001, "B0" },
                    { new Guid("0000000c-0000-0000-0000-000200000000"), 61.740000000000002, "B1" },
                    { new Guid("0000000c-0000-0000-0000-000300000000"), 123.47, "B2" },
                    { new Guid("0000000c-0000-0000-0000-000400000000"), 246.94, "B3" },
                    { new Guid("0000000c-0000-0000-0000-000500000000"), 493.88, "B4" },
                    { new Guid("0000000c-0000-0000-0000-000600000000"), 987.76999999999998, "B5" },
                    { new Guid("0000000c-0000-0000-0000-000700000000"), 1975.53, "B6" },
                    { new Guid("0000000c-0000-0000-0000-000800000000"), 3951.0700000000002, "B7" },
                    { new Guid("0000000c-0000-0000-0000-000900000000"), 7902.1300000000001, "B8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chords_ChordTypeID",
                table: "Chords",
                column: "ChordTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chords");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "ChordTypes");
        }
    }
}
