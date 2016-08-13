namespace Supreme_Brands.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userid = c.String(nullable: false),
                        firstname = c.String(),
                        lastname = c.String(),
                        middlename = c.String(),
                        email = c.String(nullable: false),
                        phone = c.String(),
                        position = c.String(nullable: false),
                        address = c.String(),
                        town = c.String(),
                        status = c.String(),
                        profile_pic = c.String(),
                        registrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RegionStaffs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SalesReps", "regionStaffId", "dbo.RegionStaffs");
            DropForeignKey("dbo.SalesReps", "profileId", "dbo.Profiles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SalesReps", new[] { "profileId" });
            DropIndex("dbo.SalesReps", new[] { "regionStaffId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SalesReps");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RegionStaffs");
            DropTable("dbo.Profiles");
        }
    }
}
