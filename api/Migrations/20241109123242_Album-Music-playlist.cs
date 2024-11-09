using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ma2_banco_de_dados.Migrations
{
    /// <inheritdoc />
    public partial class AlbumMusicplaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Music_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlist_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlbumMusic",
                columns: table => new
                {
                    AlbumsId = table.Column<int>(type: "int", nullable: false),
                    MusicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumMusic", x => new { x.AlbumsId, x.MusicsId });
                    table.ForeignKey(
                        name: "FK_AlbumMusic_Album_AlbumsId",
                        column: x => x.AlbumsId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumMusic_Music_MusicsId",
                        column: x => x.MusicsId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MusicPlaylist",
                columns: table => new
                {
                    MusicsId = table.Column<int>(type: "int", nullable: false),
                    PlaylistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylist", x => new { x.MusicsId, x.PlaylistsId });
                    table.ForeignKey(
                        name: "FK_MusicPlaylist_Music_MusicsId",
                        column: x => x.MusicsId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicPlaylist_Playlist_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMusic_MusicsId",
                table: "AlbumMusic",
                column: "MusicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Music_ArtistId",
                table: "Music",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylist_PlaylistsId",
                table: "MusicPlaylist",
                column: "PlaylistsId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UserId",
                table: "Playlist",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumMusic");

            migrationBuilder.DropTable(
                name: "MusicPlaylist");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "Playlist");
        }
    }
}
