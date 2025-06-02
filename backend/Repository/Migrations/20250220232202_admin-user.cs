using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class adminuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into public.""User"" values('30397498-64df-4a12-8ee3-d832d020a1c5', 'admin', '$2a$12$qlEY9Hyvjp.BYQU4wRUw0.VH/OnH.eOUs80T9hgp7O6yI9L.GKAnm')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM public.""User""");
        }
    }
}
