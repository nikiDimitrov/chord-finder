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
                    { new Guid("055cb057-5bbb-f872-73c2-4c18054c968f"), "A chord with a root, major third, perfect fifth, and major seventh.", "Major Seventh" },
                    { new Guid("595380d4-1d67-7bf7-2887-c358962e5338"), "A chord with a root, perfect fourth, and perfect fifth.", "Suspended Fourth" },
                    { new Guid("5e61df70-0100-e20a-69c8-d092f1209372"), "A chord with a root, minor third, perfect fifth, and minor seventh.", "Minor Seventh" },
                    { new Guid("61dc65b9-01e5-ef2d-b705-2eae57e50c7a"), "A chord with a root, minor third, and diminished fifth.", "Diminished" },
                    { new Guid("7e70584c-804f-7f03-8fd8-afc8da686c34"), "A chord with a root, minor third, and perfect fifth.", "Minor" },
                    { new Guid("a73cb2f1-78f4-c392-d35e-37112fa14f03"), "A chord with a root, major third, perfect fifth, and minor seventh.", "Dominant Seventh" },
                    { new Guid("b2197772-84d5-1d61-ec79-2862e69b7678"), "A chord with a root, minor third, diminished fifth, and minor seventh.", "Half-Diminished" },
                    { new Guid("b8530661-15ed-a4d3-99f8-20d024f8a44a"), "A chord with a root, minor third, diminished fifth, and diminished seventh.", "Diminished Seventh" },
                    { new Guid("bb3fb046-88cd-a588-917d-3901f3fefa6e"), "A chord with a root, major third, and perfect fifth.", "Major" },
                    { new Guid("e076fa8d-2f8b-94d7-fedf-d8b34a8f126a"), "A chord with a root, major second, and perfect fifth.", "Suspended Second" },
                    { new Guid("e84bf7ba-fdfa-2ed6-1b75-47da3e510c9f"), "A chord with a root, major third, and augmented fifth.", "Augmented" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "ID", "Frequency", "Name" },
                values: new object[,]
                {
                    { new Guid("012ffe52-b50a-a299-52a0-fc89fc2a3160"), 19.449999999999999, "D#0/Eb0" },
                    { new Guid("01dce9b3-66e3-52f0-9c2b-aa7f2dfc32f0"), 349.23000000000002, "F4" },
                    { new Guid("024a06fd-eeeb-b1de-a8aa-400aaa2a9b5f"), 7458.6199999999999, "A#8/Bb8" },
                    { new Guid("05e96844-a220-f783-f9f9-8e82fc1d2098"), 41.200000000000003, "E1" },
                    { new Guid("0745aa73-fe80-ffcf-6f83-2c0152c8b854"), 34.649999999999999, "C#1/Db1" },
                    { new Guid("0895fab3-5c31-b626-c469-770a3507a2c9"), 51.909999999999997, "G#1/Ab1" },
                    { new Guid("0a202004-c934-a5a1-0438-3a5cb0395f6e"), 155.56, "D#3/Eb3" },
                    { new Guid("0b77ddbc-24d8-a08b-4902-108037a9bbf0"), 466.16000000000003, "A#4/Bb4" },
                    { new Guid("0c6cb583-ffe2-ac56-0754-2f501910cc67"), 196.0, "G3" },
                    { new Guid("0e968dbe-f3d0-61a9-1b0f-912d1759e22d"), 174.61000000000001, "F3" },
                    { new Guid("0f466fff-956c-8c2a-7cab-fecb8fadedac"), 4698.6300000000001, "D8" },
                    { new Guid("10ac04b3-9c46-6dcf-5a8d-80462d2e1e96"), 92.5, "F#2/Gb2" },
                    { new Guid("14b4b091-6d17-d4f7-a455-8f0517aee58a"), 146.83000000000001, "D3" },
                    { new Guid("192a34ed-e2b2-de29-6ab0-f482d0ee05eb"), 440.0, "A4" },
                    { new Guid("1f1f3639-34b8-f52b-7629-558183c0335f"), 87.310000000000002, "F2" },
                    { new Guid("2147d5f3-6154-35b6-157a-275fbd818b98"), 311.13, "D#4/Eb4" },
                    { new Guid("222788b6-4dcb-78b3-22de-61c731b00238"), 392.0, "G4" },
                    { new Guid("229e40f8-b4f1-2bb5-2d28-5c3eec39c120"), 36.710000000000001, "D1" },
                    { new Guid("267c2cb1-3aa7-112a-5900-67086586ac35"), 1567.98, "G6" },
                    { new Guid("28158a95-490b-61d6-fb21-0a1afb12f24c"), 6271.9300000000003, "G8" },
                    { new Guid("28c4b304-1135-180d-c7de-98387d1d7472"), 293.66000000000003, "D4" },
                    { new Guid("2c2c045b-9569-dabc-1e36-a0fc150010e9"), 1046.5, "C6" },
                    { new Guid("2f87f580-9891-a94c-4f55-59677923a8bf"), 1479.98, "F#6/Gb6" },
                    { new Guid("2fdc4b71-b716-61e1-a218-682b62415b8a"), 38.890000000000001, "D#1/Eb1" },
                    { new Guid("30acc647-e77c-7489-9184-f69e8486c4bb"), 30.870000000000001, "B0" },
                    { new Guid("311468b6-4c5a-e01d-bdfa-f523276e025f"), 493.88, "B4" },
                    { new Guid("321c76b1-c3fe-28d9-3b0c-6f2b304482e8"), 20.600000000000001, "E0" },
                    { new Guid("32cdfc52-4522-d4a6-e118-62ca615bfe59"), 261.63, "C4" },
                    { new Guid("337a9e29-5551-7f63-b3ca-bc65b16fae28"), 2489.02, "D#7/Eb7" },
                    { new Guid("37a1aca8-4b36-8427-4b53-a58d06e1240f"), 1864.6600000000001, "A#6/Bb6" },
                    { new Guid("4201c61e-3620-a0bb-c059-f88a7b35dd96"), 698.46000000000004, "F5" },
                    { new Guid("4bb48c45-5456-e760-95da-8be7efa912a3"), 123.47, "B2" },
                    { new Guid("4bd07a5f-214b-ea40-c3eb-9032f6a29578"), 587.33000000000004, "D5" },
                    { new Guid("4c6cb635-e9bd-a09a-1eba-8775d819b4c6"), 24.5, "G0" },
                    { new Guid("4fa194d2-5b84-1347-b121-0a3771e5481a"), 1318.51, "E6" },
                    { new Guid("509b13da-53c2-458a-0b79-dd9b2823fa3c"), 130.81, "C3" },
                    { new Guid("53f09082-4abc-1835-1a67-512411408777"), 369.99000000000001, "F#4/Gb4" },
                    { new Guid("55080674-2dc5-b2b0-b7a0-d5fe53aff267"), 277.18000000000001, "C#4/Db4" },
                    { new Guid("55f51c10-66c3-4b7b-2714-5272565ae2b6"), 233.08000000000001, "A#3/Bb3" },
                    { new Guid("577301ea-be8c-0134-2155-a91907c4fc28"), 3729.3099999999999, "A#7/Bb7" },
                    { new Guid("6400d891-2f6a-cbe7-ea66-e7067af96f27"), 6644.8800000000001, "G#8/Ab8" },
                    { new Guid("6474bc3d-f3e3-d37e-751b-adb69144c1a1"), 523.25, "C5" },
                    { new Guid("666ffc27-b103-0b7f-d92e-2a09319b3282"), 329.63, "E4" },
                    { new Guid("67d2df14-39a5-7f28-03fe-9b9b2e7dbbbc"), 69.299999999999997, "C#2/Db2" },
                    { new Guid("6caa5e50-393a-0bd6-e93a-8c67c2fb8d13"), 58.270000000000003, "A#1/Bb1" },
                    { new Guid("6d24b5fa-22e6-27e5-76a8-8a70833f295e"), 4978.0299999999997, "D#8/Eb8" },
                    { new Guid("6f168f05-a946-72ae-95ff-0a89bfc14d06"), 18.350000000000001, "D0" },
                    { new Guid("6fb849dd-46ba-bb47-1dad-2d5b321ab6cc"), 1174.6600000000001, "D6" },
                    { new Guid("71116917-8b23-5bfb-4d35-f4ddda4c2c9d"), 82.409999999999997, "E2" },
                    { new Guid("7111bfbe-c92c-8578-8109-4e8e91d3c574"), 7040.0, "A8" },
                    { new Guid("728ae2d0-f197-7502-6e77-9ac92b03e29d"), 77.780000000000001, "D#2/Eb2" },
                    { new Guid("73f3600a-6f17-12e3-375f-a814aff40a3f"), 2637.02, "E7" },
                    { new Guid("765b6a5d-be26-9fb3-5bac-da4a1b49336f"), 1975.53, "B6" },
                    { new Guid("78cbf586-c496-ec7b-b7fd-e9225feb95e7"), 246.94, "B3" },
                    { new Guid("78f8a408-3b95-18f7-cb14-3640d2fcdc08"), 3135.96, "G7" },
                    { new Guid("7ca71c23-e9fe-cb2f-faa4-400ec140e3b1"), 1661.22, "G#6/Ab6" },
                    { new Guid("7efc446d-7426-b8ce-bdc0-4a054e5613a2"), 164.81, "E3" },
                    { new Guid("7fa1f30d-9152-895e-f9e0-3f205d4befbf"), 4186.0100000000002, "C8" },
                    { new Guid("86d591ca-d1b2-3f23-cb7b-013ed97525b8"), 138.59, "C#3/Db3" },
                    { new Guid("8790cd7c-b104-1e60-52e1-3f082bbf63c8"), 1396.9100000000001, "F6" },
                    { new Guid("87e2941f-dd13-3b18-f9fe-59aa1e4405e0"), 65.409999999999997, "C2" },
                    { new Guid("88072522-7c92-43a7-983a-c8c42d151ecf"), 220.0, "A3" },
                    { new Guid("89dfbe63-d95d-dfca-d801-bd07789d4cab"), 49.0, "G1" },
                    { new Guid("8a5586e3-2e82-a300-2faf-357766072d6e"), 3951.0700000000002, "B7" },
                    { new Guid("8bc5cf9a-63c9-a130-8101-a41c50a2ce4e"), 25.960000000000001, "G#0/Ab0" },
                    { new Guid("8dccf8b6-aa79-716b-6d7c-496ee6fa6d6c"), 46.25, "F#1/Gb1" },
                    { new Guid("92ed3e7f-7c47-2a69-cf9f-1022d0f10ec1"), 17.32, "C#0/Db0" },
                    { new Guid("9614b645-75f2-daee-24ff-7b7874645184"), 32.700000000000003, "C1" },
                    { new Guid("97f305f4-e324-ef64-6499-f6f2c127b8b8"), 116.54000000000001, "A#2/Bb2" },
                    { new Guid("9be378f9-6c5c-309c-afb1-3a3973f9cfaf"), 207.65000000000001, "G#3/Ab3" },
                    { new Guid("a02af404-6b31-7c2b-7248-4fde98cba1ed"), 932.33000000000004, "A#5/Bb5" },
                    { new Guid("a06132c8-cb82-8bea-b0a1-b86a9277f41f"), 2793.8299999999999, "F7" },
                    { new Guid("aa02a0bc-86f4-bfca-fbc0-e99eb0a43231"), 2217.46, "C#7/Db7" },
                    { new Guid("aaa051ca-9124-6810-b997-8dc1772c052d"), 110.0, "A2" },
                    { new Guid("ad49df17-3411-3ab3-afa3-b9cdc31417db"), 3322.4400000000001, "G#7/Ab7" },
                    { new Guid("b6a81f5d-b02e-7b88-e498-fc2b931e481c"), 27.5, "A0" },
                    { new Guid("bb66b225-af27-5928-7a3e-773218b7219a"), 185.0, "F#3/Gb3" },
                    { new Guid("bc028248-abbe-ef88-1ef5-a307fa01ae15"), 7902.1300000000001, "B8" },
                    { new Guid("bff34eae-5455-ead1-f8a6-c44af625430a"), 2349.3200000000002, "D7" },
                    { new Guid("c203ff44-4571-7830-1a1e-d124f5905f19"), 2959.96, "F#7/Gb7" },
                    { new Guid("c2301d9a-4686-9d60-3f90-088f3fc1af9a"), 783.99000000000001, "G5" },
                    { new Guid("c549ab0d-baf1-eced-4392-ded46052eb43"), 73.420000000000002, "D2" },
                    { new Guid("d0b41f7e-d8e6-aaec-3ab0-ada37e84a3a6"), 739.99000000000001, "F#5/Gb5" },
                    { new Guid("d38dc0eb-5f4e-a663-7a5c-53c42d2501ed"), 29.140000000000001, "A#0/Bb0" },
                    { new Guid("d4bf6a6e-f7dd-9588-7c94-7c6baf985d4c"), 5274.04, "E8" },
                    { new Guid("d82ed794-c832-6af0-f5a1-6f932da8562d"), 5919.9099999999999, "F#8/Gb8" },
                    { new Guid("db6734b3-568b-ccd0-8eb2-30a0411ca8fd"), 55.0, "A1" },
                    { new Guid("e2186f68-576f-3dfb-af59-706e510e1ffb"), 61.740000000000002, "B1" },
                    { new Guid("e49a595e-967a-c96e-c095-5309a42fdd40"), 103.83, "G#2/Ab2" },
                    { new Guid("e50bf423-59eb-a5a4-68e0-2952a0cff88e"), 987.76999999999998, "B5" },
                    { new Guid("e6375fbd-0f6a-e8fe-9e4e-1db98b845cb4"), 16.350000000000001, "C0" },
                    { new Guid("e7c292d2-9f00-8f29-da6d-b24aa2ad645c"), 98.0, "G2" },
                    { new Guid("e8b66d03-c404-401b-0975-2e057d0afb44"), 659.25, "E5" },
                    { new Guid("ee935a32-e778-1a61-ccf2-5e39fbe7c7bb"), 3520.0, "A7" },
                    { new Guid("ef76bccb-bd0d-7c5a-14b5-bfecb61055b4"), 5587.6499999999996, "F8" },
                    { new Guid("efb1fb2c-6831-6e9e-c701-7e723016e2bd"), 880.0, "A5" },
                    { new Guid("f1d78d9c-c473-b74d-f560-d140dabf4da2"), 21.829999999999998, "F0" },
                    { new Guid("f3ad729a-f5ba-394c-05c1-d7114c4c6a39"), 1108.73, "C#6/Db6" },
                    { new Guid("f3d90171-b9fe-d300-e6af-baf175248690"), 4434.9200000000001, "C#8/Db8" },
                    { new Guid("f3f50a00-06e3-d40f-5ad5-4ab482520476"), 2093.0, "C7" },
                    { new Guid("f5551cdf-4812-5163-a811-7392fe875fd9"), 43.649999999999999, "F1" },
                    { new Guid("f60cae08-217c-8936-ff2f-0c7d0c32d704"), 830.61000000000001, "G#5/Ab5" },
                    { new Guid("fb0dafd5-f6b4-98b8-e187-04a0cc7ca9e9"), 1760.0, "A6" },
                    { new Guid("fd9ea151-b9de-f0da-9106-14164ce76bfa"), 622.25, "D#5/Eb5" },
                    { new Guid("fdc2da21-443f-fc9f-c09b-1ed8e7262601"), 415.30000000000001, "G#4/Ab4" },
                    { new Guid("fe57aca4-13ae-090b-af7c-671d247a6836"), 1244.51, "D#6/Eb6" },
                    { new Guid("fe6ba18c-31e2-b5ad-5fa2-b99fbc5e783e"), 23.120000000000001, "F#0/Gb0" },
                    { new Guid("fea2b844-9c1d-9460-3523-b3e54873be76"), 554.37, "C#5/Db5" }
                });

            migrationBuilder.InsertData(
                table: "Chords",
                columns: new[] { "ID", "ChordTypeID", "Name", "Notes" },
                values: new object[,]
                {
                    { new Guid("07f4b5fa-d3a5-8513-3b1c-4e9f31dcd23e"), new Guid("a73cb2f1-78f4-c392-d35e-37112fa14f03"), "F#/Gb7", "F#/Gb-A#/Bb-C#/Db-E" },
                    { new Guid("0a599c24-4f62-fd12-d240-19c026723381"), new Guid("595380d4-1d67-7bf7-2887-c358962e5338"), "Fsus4", "F-A#/Bb-C" },
                    { new Guid("0da342ee-1aa2-8b45-8e29-62c4407fd3eb"), new Guid("a73cb2f1-78f4-c392-d35e-37112fa14f03"), "D7", "D-F#/Gb-A-C" },
                    { new Guid("0e2be71a-6bbb-e01d-2c2c-ef94e4eb1319"), new Guid("7e70584c-804f-7f03-8fd8-afc8da686c34"), "Gm", "G-A#/Bb-D" },
                    { new Guid("0ec3504d-aa84-198d-5e5c-39a25c4b01f3"), new Guid("b2197772-84d5-1d61-ec79-2862e69b7678"), "Eø7", "E-G-A#/Bb-D" },
                    { new Guid("11ae4cfd-4cae-38c6-fdab-5bbc632afea2"), new Guid("b8530661-15ed-a4d3-99f8-20d024f8a44a"), "Fdim7", "F-G#/Ab-B-D" },
                    { new Guid("129a9e43-6a73-ebdb-674c-1cbb3472d376"), new Guid("5e61df70-0100-e20a-69c8-d092f1209372"), "Fmin7", "F-G#/Ab-C-D#/Eb" },
                    { new Guid("13aaee76-1059-d87c-4951-d519b0b0a709"), new Guid("7e70584c-804f-7f03-8fd8-afc8da686c34"), "F#/Gbm", "F#/Gb-A-C#/Db" },
                    { new Guid("15a3ef3e-9eaa-7169-d6ee-c01657c4ba28"), new Guid("61dc65b9-01e5-ef2d-b705-2eae57e50c7a"), "Fdim", "F-G#/Ab-B" },
                    { new Guid("167c73c4-0da8-294b-6a7d-75c8ec4fa0a8"), new Guid("61dc65b9-01e5-ef2d-b705-2eae57e50c7a"), "Ddim", "D-F-G#/Ab" },
                    { new Guid("18273616-0bca-399a-58e9-3488d5124179"), new Guid("055cb057-5bbb-f872-73c2-4c18054c968f"), "F#/Gbmaj7", "F#/Gb-A#/Bb-C#/Db-F" },
                    { new Guid("194de801-e3e8-2445-065c-0c551e46434e"), new Guid("055cb057-5bbb-f872-73c2-4c18054c968f"), "Dmaj7", "D-F#/Gb-A-C#/Db" },
                    { new Guid("1e5e028a-f076-2180-4c22-31a5b21092ed"), new Guid("e84bf7ba-fdfa-2ed6-1b75-47da3e510c9f"), "Caug", "C-E-G#/Ab" },
                    { new Guid("1e888e4e-9430-f77d-5829-f877e9e624ef"), new Guid("e076fa8d-2f8b-94d7-fedf-d8b34a8f126a"), "Fsus2", "F-G-C" },
                    { new Guid("21ba926e-c5da-35d3-904b-403c4ca47b14"), new Guid("bb3fb046-88cd-a588-917d-3901f3fefa6e"), "C#/Db", "C#/Db-F-G#/Ab" },
                    { new Guid("2255d3eb-03ec-c352-14b9-6068067bb05d"), new Guid("b8530661-15ed-a4d3-99f8-20d024f8a44a"), "Gdim7", "G-A#/Bb-C#/Db-E" },
                    { new Guid("277a6339-8854-786f-61fc-dc35ab8101bd"), new Guid("e076fa8d-2f8b-94d7-fedf-d8b34a8f126a"), "F#/Gbsus2", "F#/Gb-G#/Ab-C#/Db" },
                    { new Guid("292faf65-a013-5328-171a-eb78e0bbfcfb"), new Guid("a73cb2f1-78f4-c392-d35e-37112fa14f03"), "C#/Db7", "C#/Db-F-G#/Ab-B" },
                    { new Guid("2b362b88-c423-db16-3699-b7b0c008278a"), new Guid("bb3fb046-88cd-a588-917d-3901f3fefa6e"), "D#/Eb", "D#/Eb-G-A#/Bb" },
                    { new Guid("2bbf9869-3029-870c-829a-2e4ddca36ee9"), new Guid("7e70584c-804f-7f03-8fd8-afc8da686c34"), "C#/Dbm", "C#/Db-E-G#/Ab" },
                    { new Guid("2cae58c2-e790-20d7-9e30-94c177ea64e6"), new Guid("61dc65b9-01e5-ef2d-b705-2eae57e50c7a"), "Gdim", "G-A#/Bb-C#/Db" },
                    { new Guid("30c4b848-18cc-651a-5b1d-436883d47741"), new Guid("e84bf7ba-fdfa-2ed6-1b75-47da3e510c9f"), "Faug", "F-A-C#/Db" },
                    { new Guid("32bdb599-d0ea-8de0-3ed1-25c368cd2399"), new Guid("595380d4-1d67-7bf7-2887-c358962e5338"), "C#/Dbsus4", "C#/Db-F#/Gb-G#/Ab" },
                    { new Guid("3525a0e0-d15f-db65-cba4-aeb5ced7c803"), new Guid("e84bf7ba-fdfa-2ed6-1b75-47da3e510c9f"), "Gaug", "G-B-D#/Eb" },
                    { new Guid("3c598743-003c-203a-8d53-ec3609f9a97c"), new Guid("61dc65b9-01e5-ef2d-b705-2eae57e50c7a"), "Cdim", "C-D#/Eb-F#/Gb" },
                    { new Guid("419ece1d-4a0f-32f4-fee2-c05028a73087"), new Guid("b2197772-84d5-1d61-ec79-2862e69b7678"), "Fø7", "F-G#/Ab-B-D#/Eb" },
                    { new Guid("52228710-05bb-2512-099c-d23ff0fcace3"), new Guid("595380d4-1d67-7bf7-2887-c358962e5338"), "Csus4", "C-F-G" },
                    { new Guid("561949d3-ede3-00c0-97ad-cbbd6cec06c8"), new Guid("a73cb2f1-78f4-c392-d35e-37112fa14f03"), "E7", "E-G#/Ab-B-D" },
                    { new Guid("586c4bf8-1a3d-4914-547f-3ba7ea12dd04"), new Guid("7e70584c-804f-7f03-8fd8-afc8da686c34"), "Fm", "F-G#/Ab-C" },
                    { new Guid("58a0f710-fc54-ac25-b5c2-32805b0c8b5a"), new Guid("a73cb2f1-78f4-c392-d35e-37112fa14f03"), "D#/Eb7", "D#/Eb-G-A#/Bb-C#/Db" },
                    { new Guid("60f2a89a-2275-4029-690c-cdae242b9522"), new Guid("b8530661-15ed-a4d3-99f8-20d024f8a44a"), "Ddim7", "D-F-G#/Ab-B" },
                    { new Guid("62daaca6-1a0c-1310-352e-fdf1d3d7cb41"), new Guid("b8530661-15ed-a4d3-99f8-20d024f8a44a"), "Cdim7", "C-D#/Eb-F#/Gb-A" },
                    { new Guid("6a0e81ad-1180-fdcd-58d1-338c8379f6d4"), new Guid("e84bf7ba-fdfa-2ed6-1b75-47da3e510c9f"), "Eaug", "E-G#/Ab-C" },
                    { new Guid("6bd46feb-cacc-9236-11f0-afc713892088"), new Guid("e84bf7ba-fdfa-2ed6-1b75-47da3e510c9f"), "F#/Gbaug", "F#/Gb-A#/Bb-D" },
                    { new Guid("6e548e78-1b36-8e35-3f90-534276a2fe92"), new Guid("61dc65b9-01e5-ef2d-b705-2eae57e50c7a"), "D#/Ebdim", "D#/Eb-F#/Gb-A" },
                    { new Guid("6e848f45-0937-d22c-7869-b24835b89d16"), new Guid("5e61df70-0100-e20a-69c8-d092f1209372"), "Emin7", "E-G-B-D" },
                    { new Guid("6f8d29f6-d8dd-42ab-e735-54288e354f0a"), new Guid("055cb057-5bbb-f872-73c2-4c18054c968f"), "Cmaj7", "C-E-G-B" },
                    { new Guid("72b474ae-0169-4761-ccce-f6524fe8c28b"), new Guid("7e70584c-804f-7f03-8fd8-afc8da686c34"), "Cm", "C-D#/Eb-G" },
                    { new Guid("73d4eebe-bdc0-e93f-b60a-99915decc71a"), new Guid("b2197772-84d5-1d61-ec79-2862e69b7678"), "C#/Dbø7", "C#/Db-E-G-B" },
                    { new Guid("7b33dd78-c6e2-9ad6-06a7-696fcffc9cd9"), new Guid("055cb057-5bbb-f872-73c2-4c18054c968f"), "Gmaj7", "G-B-D-F#/Gb" },
                    { new Guid("7c3d3093-a168-5f14-9d4d-0a1e28d34711"), new Guid("61dc65b9-01e5-ef2d-b705-2eae57e50c7a"), "F#/Gbdim", "F#/Gb-A-C" },
                    { new Guid("7d67ef01-1f66-d598-434c-f23f87a12db2"), new Guid("5e61df70-0100-e20a-69c8-d092f1209372"), "Cmin7", "C-D#/Eb-G-A#/Bb" },
                    { new Guid("80fe8d83-e37c-78e3-e674-62d77cac8e04"), new Guid("bb3fb046-88cd-a588-917d-3901f3fefa6e"), "E", "E-G#/Ab-B" },
                    { new Guid("82fed50d-0dae-aac4-9774-f3c7e7624104"), new Guid("bb3fb046-88cd-a588-917d-3901f3fefa6e"), "C", "C-E-G" },
                    { new Guid("8d173d3a-fc16-dc7a-df2e-9968ca6fc9ee"), new Guid("b8530661-15ed-a4d3-99f8-20d024f8a44a"), "C#/Dbdim7", "C#/Db-E-G-A#/Bb" },
                    { new Guid("8f344ad8-2d73-685b-2758-a808e2e87e58"), new Guid("595380d4-1d67-7bf7-2887-c358962e5338"), "Dsus4", "D-G-A" },
                    { new Guid("94b60023-9a77-3cce-1144-ff411277e63d"), new Guid("5e61df70-0100-e20a-69c8-d092f1209372"), "Dmin7", "D-F-A-C" },
                    { new Guid("955a6179-8088-e2c1-836c-46ae5629f32d"), new Guid("bb3fb046-88cd-a588-917d-3901f3fefa6e"), "F", "F-A-C" },
                    { new Guid("990b9cae-fa42-540c-5612-6f5c23656d1d"), new Guid("bb3fb046-88cd-a588-917d-3901f3fefa6e"), "F#/Gb", "F#/Gb-A#/Bb-C#/Db" },
                    { new Guid("9e690599-d7ed-057e-66b3-60ed7eebad1c"), new Guid("61dc65b9-01e5-ef2d-b705-2eae57e50c7a"), "C#/Dbdim", "C#/Db-E-G" },
                    { new Guid("a0edc0f2-fbca-2f85-1980-9d065ee3d30a"), new Guid("5e61df70-0100-e20a-69c8-d092f1209372"), "C#/Dbmin7", "C#/Db-E-G#/Ab-B" },
                    { new Guid("a25d01e2-f473-8c12-f3a5-bfeab89ec20e"), new Guid("595380d4-1d67-7bf7-2887-c358962e5338"), "D#/Ebsus4", "D#/Eb-G#/Ab-A#/Bb" },
                    { new Guid("a3b31824-b523-01b7-e2a2-c1953ccef810"), new Guid("7e70584c-804f-7f03-8fd8-afc8da686c34"), "Em", "E-G-B" },
                    { new Guid("a4d4b60f-4e6b-4f8a-078c-6ad34e860982"), new Guid("e076fa8d-2f8b-94d7-fedf-d8b34a8f126a"), "D#/Ebsus2", "D#/Eb-F-A#/Bb" },
                    { new Guid("a4d571dd-0c02-94eb-288a-183c40e491f6"), new Guid("b8530661-15ed-a4d3-99f8-20d024f8a44a"), "Edim7", "E-G-A#/Bb-C#/Db" },
                    { new Guid("a794c569-7ed9-0c82-e4c0-573aa61d32d6"), new Guid("bb3fb046-88cd-a588-917d-3901f3fefa6e"), "G", "G-B-D" },
                    { new Guid("a9760675-74e2-43e1-89b5-5cf74edd654b"), new Guid("b2197772-84d5-1d61-ec79-2862e69b7678"), "Cø7", "C-D#/Eb-F#/Gb-A#/Bb" },
                    { new Guid("ab8f61ec-6135-86f8-fe75-1561e445f8e8"), new Guid("055cb057-5bbb-f872-73c2-4c18054c968f"), "D#/Ebmaj7", "D#/Eb-G-A#/Bb-D" },
                    { new Guid("ad941816-1545-b96a-09f8-21c29481bbd4"), new Guid("5e61df70-0100-e20a-69c8-d092f1209372"), "F#/Gbmin7", "F#/Gb-A-C#/Db-E" },
                    { new Guid("b1bda7f2-10e0-0137-c252-03ca58e3a1f0"), new Guid("5e61df70-0100-e20a-69c8-d092f1209372"), "D#/Ebmin7", "D#/Eb-F#/Gb-A#/Bb-C#/Db" },
                    { new Guid("b6042751-ab84-68a8-b417-814f3fb1bf2e"), new Guid("a73cb2f1-78f4-c392-d35e-37112fa14f03"), "C7", "C-E-G-A#/Bb" },
                    { new Guid("b8d05a8e-4263-5178-0f43-b31feb950420"), new Guid("a73cb2f1-78f4-c392-d35e-37112fa14f03"), "F7", "F-A-C-D#/Eb" },
                    { new Guid("bbc52a79-6425-6bda-da4d-8282d0d4183e"), new Guid("e076fa8d-2f8b-94d7-fedf-d8b34a8f126a"), "Gsus2", "G-A-D" },
                    { new Guid("bd9211f5-a918-8c4d-b027-110ad79e1768"), new Guid("e076fa8d-2f8b-94d7-fedf-d8b34a8f126a"), "Csus2", "C-D-G" },
                    { new Guid("c1ac2103-b769-89ab-a16b-4ffacec20385"), new Guid("e076fa8d-2f8b-94d7-fedf-d8b34a8f126a"), "Esus2", "E-F#/Gb-B" },
                    { new Guid("c1dd25f5-4740-89c6-1fa0-bf8bafa0dc2f"), new Guid("61dc65b9-01e5-ef2d-b705-2eae57e50c7a"), "Edim", "E-G-A#/Bb" },
                    { new Guid("c30b5998-570a-d0be-fcf6-da9f450dd035"), new Guid("b2197772-84d5-1d61-ec79-2862e69b7678"), "Gø7", "G-A#/Bb-C#/Db-F" },
                    { new Guid("c5460f74-9ae4-40e2-0b28-2c10e5eb3174"), new Guid("b2197772-84d5-1d61-ec79-2862e69b7678"), "F#/Gbø7", "F#/Gb-A-C-E" },
                    { new Guid("c67c4b50-279d-e530-4191-12efffe84ede"), new Guid("595380d4-1d67-7bf7-2887-c358962e5338"), "Esus4", "E-A-B" },
                    { new Guid("ca6db4d2-4648-5fc4-7c79-3aebfbdac8c2"), new Guid("e84bf7ba-fdfa-2ed6-1b75-47da3e510c9f"), "C#/Dbaug", "C#/Db-F-A" },
                    { new Guid("cc4a6973-5082-420f-f1e0-c26a668e0463"), new Guid("b2197772-84d5-1d61-ec79-2862e69b7678"), "D#/Ebø7", "D#/Eb-F#/Gb-A-C#/Db" },
                    { new Guid("cefd1d4d-ced1-0472-bb22-8e7bc3ed73e0"), new Guid("e84bf7ba-fdfa-2ed6-1b75-47da3e510c9f"), "Daug", "D-F#/Gb-A#/Bb" },
                    { new Guid("cf0b26f5-1e17-5b4a-91ad-5220b5f0c567"), new Guid("055cb057-5bbb-f872-73c2-4c18054c968f"), "Fmaj7", "F-A-C-E" },
                    { new Guid("cf1c76f7-6aa6-5581-56b1-887808744dcf"), new Guid("595380d4-1d67-7bf7-2887-c358962e5338"), "F#/Gbsus4", "F#/Gb-B-C#/Db" },
                    { new Guid("d4fbc7f5-7e7b-5ae3-edcf-588ec65214cb"), new Guid("055cb057-5bbb-f872-73c2-4c18054c968f"), "Emaj7", "E-G#/Ab-B-D#/Eb" },
                    { new Guid("d78abb6a-bf59-512b-5270-cd17e8201ca7"), new Guid("b2197772-84d5-1d61-ec79-2862e69b7678"), "Dø7", "D-F-G#/Ab-C" },
                    { new Guid("d8c1f301-e0dc-a06d-d3b7-995aba6b2f24"), new Guid("e076fa8d-2f8b-94d7-fedf-d8b34a8f126a"), "C#/Dbsus2", "C#/Db-D#/Eb-G#/Ab" },
                    { new Guid("d8c34eed-47e4-41a5-a893-81be91f4b038"), new Guid("595380d4-1d67-7bf7-2887-c358962e5338"), "Gsus4", "G-C-D" },
                    { new Guid("de61ff2b-5cca-be00-2e6b-5d67fd19049a"), new Guid("bb3fb046-88cd-a588-917d-3901f3fefa6e"), "D", "D-F#/Gb-A" },
                    { new Guid("e3724539-a8e2-2d08-533c-1dd7de6dda0d"), new Guid("7e70584c-804f-7f03-8fd8-afc8da686c34"), "Dm", "D-F-A" },
                    { new Guid("e5475335-48ac-dc67-3e3d-84d40624589f"), new Guid("e076fa8d-2f8b-94d7-fedf-d8b34a8f126a"), "Dsus2", "D-E-A" },
                    { new Guid("e5bd16d6-5f2f-5de3-1f43-51141d31e4c2"), new Guid("7e70584c-804f-7f03-8fd8-afc8da686c34"), "D#/Ebm", "D#/Eb-F#/Gb-A#/Bb" },
                    { new Guid("e67dd7e8-fd68-7932-f73a-e6908356b14e"), new Guid("b8530661-15ed-a4d3-99f8-20d024f8a44a"), "F#/Gbdim7", "F#/Gb-A-C-D#/Eb" },
                    { new Guid("e6fc459f-e76c-3110-7106-88475ce6bf63"), new Guid("5e61df70-0100-e20a-69c8-d092f1209372"), "Gmin7", "G-A#/Bb-D-F" },
                    { new Guid("ef4a17a9-a3d3-8a06-620b-8ad5eaf6ceab"), new Guid("e84bf7ba-fdfa-2ed6-1b75-47da3e510c9f"), "D#/Ebaug", "D#/Eb-G-B" },
                    { new Guid("f1eb3b4f-ffe2-3aa0-aa39-942838baf36f"), new Guid("a73cb2f1-78f4-c392-d35e-37112fa14f03"), "G7", "G-B-D-F" },
                    { new Guid("f5ae5e52-e014-832f-6ae0-a61ae7803492"), new Guid("b8530661-15ed-a4d3-99f8-20d024f8a44a"), "D#/Ebdim7", "D#/Eb-F#/Gb-A-C" },
                    { new Guid("fc82b277-ac2b-603c-66f8-58dac0262038"), new Guid("055cb057-5bbb-f872-73c2-4c18054c968f"), "C#/Dbmaj7", "C#/Db-F-G#/Ab-C" }
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
