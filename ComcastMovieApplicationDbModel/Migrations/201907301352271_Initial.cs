namespace ComcastMovieApplicationDbModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieRatings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        YearOfRelease = c.Int(nullable: false),
                        RunningTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieRatings", "UserId", "dbo.Users");
            DropForeignKey("dbo.MovieRatings", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieRatings", new[] { "UserId" });
            DropIndex("dbo.MovieRatings", new[] { "MovieId" });
            DropTable("dbo.Users");
            DropTable("dbo.Movies");
            DropTable("dbo.MovieRatings");
        }
    }
}
