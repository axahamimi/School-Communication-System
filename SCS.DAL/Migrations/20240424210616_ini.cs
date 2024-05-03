using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DegreeTypes",
                columns: table => new
                {
                    DegreeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeTypeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DegreeTy__DD0FA03F989A78C7", x => x.DegreeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__B2079BED2D6C38DB", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__8AFACE1AB92E2539", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sections__80EF0872CDC94C33", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    TermId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Terms__410A21A58BFEAF71", x => x.TermId);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Levels__09F03C26DD3AFEE2", x => x.LevelId);
                    table.ForeignKey(
                        name: "FK__Levels__Departme__403A8C7D",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Usernumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Userpassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CC4C467C8E13", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__Users__RoleId__398D8EEE",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "LaibaryBooks",
                columns: table => new
                {
                    LaibaryBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sectionid = table.Column<int>(type: "int", nullable: false),
                    LaibaryBookName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LaibaryBookPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LaibaryB__FC3D9298FAEF7CC5", x => x.LaibaryBookId);
                    table.ForeignKey(
                        name: "FK__LaibaryBo__Secti__0C85DE4D",
                        column: x => x.Sectionid,
                        principalTable: "Sections",
                        principalColumn: "SectionId");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubjectBook1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SubjectBook2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SubjectBook3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subjects__AC1BA3A827384BB8", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK__Subjects__LevelI__46E78A0C",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId");
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    ClassSopervisor = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Classes__CB1927C0A43DC339", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK__Classes__ClassSo__440B1D61",
                        column: x => x.ClassSopervisor,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__Classes__LevelId__4316F928",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NotificationTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NotificationText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__20CF2E12C5C02ECF", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK__Notificat__UserI__17036CC0",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentSubervaisorChats",
                columns: table => new
                {
                    ParentSubervaisorChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<int>(type: "int", nullable: false),
                    Recever = table.Column<int>(type: "int", nullable: false),
                    ParentSubervaisorChatText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentSubervaisorChatImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentSubervaisorChatFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentSubervaisorChatDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ParentSu__5CE078C8914C6D9B", x => x.ParentSubervaisorChatId);
                    table.ForeignKey(
                        name: "FK__ParentSub__Recev__14270015",
                        column: x => x.Recever,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__ParentSub__Sende__1332DBDC",
                        column: x => x.Sender,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TeacherAttendances",
                columns: table => new
                {
                    TeacherAttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeacherAttendanceValue = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TeacherAttendanceDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherA__678A48105127EB87", x => x.TeacherAttendanceId);
                    table.ForeignKey(
                        name: "FK__TeacherAt__UserI__07C12930",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherEvaluations",
                columns: table => new
                {
                    TeacherEvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeacherEvaluationValue = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TeacherEvaluationValueTow = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherE__0F0C6E4734850A4E", x => x.TeacherEvaluationId);
                    table.ForeignKey(
                        name: "FK__TeacherEv__UserI__04E4BC85",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTimeTables",
                columns: table => new
                {
                    TeacherTimeTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeacherTimeTableImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherT__466F62C46668223E", x => x.TeacherTimeTableId);
                    table.ForeignKey(
                        name: "FK__TeacherTi__UserI__5629CD9C",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StedentParent = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__32C52B991EF14DA2", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK__Students__ClassI__5070F446",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK__Students__Steden__4F7CD00D",
                        column: x => x.StedentParent,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__Students__UserId__4E88ABD4",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTimeTables",
                columns: table => new
                {
                    StudentTimeTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classid = table.Column<int>(type: "int", nullable: false),
                    StudentTimeTableImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentT__AA15A797DF37C1F4", x => x.StudentTimeTableId);
                    table.ForeignKey(
                        name: "FK__StudentTi__Class__534D60F1",
                        column: x => x.Classid,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectClasses",
                columns: table => new
                {
                    SubjectClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SubjectTeacher = table.Column<int>(type: "int", nullable: false),
                    SubjectClassName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubjectC__56E2859A3B35A6C6", x => x.SubjectClassId);
                    table.ForeignKey(
                        name: "FK__SubjectCl__Class__49C3F6B7",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__SubjectCl__Subje__4AB81AF0",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK__SubjectCl__Subje__4BAC3F29",
                        column: x => x.SubjectTeacher,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "NotificationRoles",
                columns: table => new
                {
                    NotificationRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    NotificationRoleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__D523AA9054D92CD0", x => x.NotificationRoleId);
                    table.ForeignKey(
                        name: "FK__Notificat__Notif__19DFD96B",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Notificat__RoleI__1AD3FDA4",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubervisorNotifications",
                columns: table => new
                {
                    SubervisorNotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subervis__C7602C358A7AD4E2", x => x.SubervisorNotificationId);
                    table.ForeignKey(
                        name: "FK__Suberviso__Class__22751F6C",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Suberviso__Notif__2180FB33",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassChats",
                columns: table => new
                {
                    ClassChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classid = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    ClassChatText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassChatImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassChatFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassChatDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClassCha__366737B7853C99E7", x => x.ClassChatId);
                    table.ForeignKey(
                        name: "FK__ClassChat__Class__0F624AF8",
                        column: x => x.Classid,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ClassChat__Stude__10566F31",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DegreeFiles",
                columns: table => new
                {
                    DegreeFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    DegreeTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DegreeFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DegreeFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DegreeFi__BE204451D78EA090", x => x.DegreeFileId);
                    table.ForeignKey(
                        name: "FK__DegreeFil__Degre__619B8048",
                        column: x => x.DegreeTypeId,
                        principalTable: "DegreeTypes",
                        principalColumn: "DegreeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DegreeFil__Stude__628FA481",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DegreeFil__TermI__60A75C0F",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId");
                });

            migrationBuilder.CreateTable(
                name: "StudentAttendances",
                columns: table => new
                {
                    StudentAttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    StudentAttendanceValue = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StudentAttendanceDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentA__6342645B998B6F8C", x => x.StudentAttendanceId);
                    table.ForeignKey(
                        name: "FK__StudentAt__Stude__01142BA1",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentAt__TermI__02084FDA",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSuggestions",
                columns: table => new
                {
                    StudentSuggestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    StudentSuggestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentSuggestionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentSuggestionDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentS__699998993E593C88", x => x.StudentSuggestionId);
                    table.ForeignKey(
                        name: "FK__StudentSu__Class__7A672E12",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentSu__Stude__797309D9",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpNoteBooks",
                columns: table => new
                {
                    FollowUpNoteBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    FollowUpNoteBookText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowUpNoteBookDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FollowUp__64828509BE018E62", x => x.FollowUpNoteBookId);
                    table.ForeignKey(
                        name: "FK__FollowUpN__Class__75A278F5",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK__FollowUpN__Subje__74AE54BC",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FollowUpN__TermI__76969D2E",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeWorks",
                columns: table => new
                {
                    HomeWorkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    HomeWorkDegree = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    HomeWorkTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HomeWorkdescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeWorkText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeWorkFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeWorkImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeWorkDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HomeWork__C49C7058C45406AA", x => x.HomeWorkId);
                    table.ForeignKey(
                        name: "FK__HomeWorks__Subje__656C112C",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__HomeWorks__TermI__66603565",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reinforcementlessons",
                columns: table => new
                {
                    ReinforcementlessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    ReinforcementlessonTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Reinforcementlessondescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReinforcementlessonFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reinforcementlessonlink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReinforcementlessonDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reinforc__B162A1F24B334BFB", x => x.ReinforcementlessonId);
                    table.ForeignKey(
                        name: "FK__Reinforce__Subje__7D439ABD",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Reinforce__TermI__7E37BEF6",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDegrees",
                columns: table => new
                {
                    StudentDegreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    DegreeTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentDegreeValue = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    StudentDegreenote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentD__0CC89BAD4CA02FF8", x => x.StudentDegreeId);
                    table.ForeignKey(
                        name: "FK__StudentDe__Degre__5DCAEF64",
                        column: x => x.DegreeTypeId,
                        principalTable: "DegreeTypes",
                        principalColumn: "DegreeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentDe__Stude__5BE2A6F2",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentDe__Subje__5AEE82B9",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentDe__TermI__5CD6CB2B",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId");
                });

            migrationBuilder.CreateTable(
                name: "StudentQeustions",
                columns: table => new
                {
                    StudentQeustionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    StudentQeustionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentQeustionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentQeustionDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentQ__A171725E580C4668", x => x.StudentQeustionId);
                    table.ForeignKey(
                        name: "FK__StudentQe__Stude__6E01572D",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentQe__Subje__6D0D32F4",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentQe__TermI__6EF57B66",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherNotifications",
                columns: table => new
                {
                    TeacherNotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherN__2AF3B401732B9ACC", x => x.TeacherNotificationId);
                    table.ForeignKey(
                        name: "FK__TeacherNo__Notif__1DB06A4F",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__TeacherNo__Subje__1EA48E88",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    SolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeWorkId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SolutionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SolutionDegree = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Solutionnote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Solution__6B633AD08345CAC6", x => x.SolutionId);
                    table.ForeignKey(
                        name: "FK__Solutions__HomeW__693CA210",
                        column: x => x.HomeWorkId,
                        principalTable: "HomeWorks",
                        principalColumn: "HomeWorkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Solutions__Stude__6A30C649",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAnswers",
                columns: table => new
                {
                    TeacherAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentQeustionId = table.Column<int>(type: "int", nullable: false),
                    TeacherAnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherAnswerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherAnswerDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherA__A3B38DF996FAA0AC", x => x.TeacherAnswerId);
                    table.ForeignKey(
                        name: "FK__TeacherAn__Stude__71D1E811",
                        column: x => x.StudentQeustionId,
                        principalTable: "StudentQeustions",
                        principalColumn: "StudentQeustionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassChats_Classid",
                table: "ClassChats",
                column: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_ClassChats_StudentId",
                table: "ClassChats",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassSopervisor",
                table: "Classes",
                column: "ClassSopervisor");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_LevelId",
                table: "Classes",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeFiles_DegreeTypeId",
                table: "DegreeFiles",
                column: "DegreeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeFiles_StudentId",
                table: "DegreeFiles",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeFiles_TermId",
                table: "DegreeFiles",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpNoteBooks_ClassId",
                table: "FollowUpNoteBooks",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpNoteBooks_SubjectClassId",
                table: "FollowUpNoteBooks",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpNoteBooks_TermId",
                table: "FollowUpNoteBooks",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_SubjectClassId",
                table: "HomeWorks",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_TermId",
                table: "HomeWorks",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_LaibaryBooks_Sectionid",
                table: "LaibaryBooks",
                column: "Sectionid");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_DepartmentId",
                table: "Levels",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRoles_NotificationId",
                table: "NotificationRoles",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRoles_RoleId",
                table: "NotificationRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentSubervaisorChats_Recever",
                table: "ParentSubervaisorChats",
                column: "Recever");

            migrationBuilder.CreateIndex(
                name: "IX_ParentSubervaisorChats_Sender",
                table: "ParentSubervaisorChats",
                column: "Sender");

            migrationBuilder.CreateIndex(
                name: "IX_Reinforcementlessons_SubjectClassId",
                table: "Reinforcementlessons",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Reinforcementlessons_TermId",
                table: "Reinforcementlessons",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_HomeWorkId",
                table: "Solutions",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_StudentId",
                table: "Solutions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_TermId",
                table: "StudentAttendances",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDegrees_DegreeTypeId",
                table: "StudentDegrees",
                column: "DegreeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDegrees_StudentId",
                table: "StudentDegrees",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDegrees_SubjectClassId",
                table: "StudentDegrees",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDegrees_TermId",
                table: "StudentDegrees",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQeustions_StudentId",
                table: "StudentQeustions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQeustions_SubjectClassId",
                table: "StudentQeustions",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQeustions_TermId",
                table: "StudentQeustions",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StedentParent",
                table: "Students",
                column: "StedentParent");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSuggestions_ClassId",
                table: "StudentSuggestions",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSuggestions_StudentId",
                table: "StudentSuggestions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTimeTables_Classid",
                table: "StudentTimeTables",
                column: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_SubervisorNotifications_ClassId",
                table: "SubervisorNotifications",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubervisorNotifications_NotificationId",
                table: "SubervisorNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClasses_ClassId",
                table: "SubjectClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClasses_SubjectId",
                table: "SubjectClasses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClasses_SubjectTeacher",
                table: "SubjectClasses",
                column: "SubjectTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LevelId",
                table: "Subjects",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAnswers_StudentQeustionId",
                table: "TeacherAnswers",
                column: "StudentQeustionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAttendances_UserId",
                table: "TeacherAttendances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherEvaluations_UserId",
                table: "TeacherEvaluations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherNotifications_NotificationId",
                table: "TeacherNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherNotifications_SubjectClassId",
                table: "TeacherNotifications",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTimeTables_UserId",
                table: "TeacherTimeTables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassChats");

            migrationBuilder.DropTable(
                name: "DegreeFiles");

            migrationBuilder.DropTable(
                name: "FollowUpNoteBooks");

            migrationBuilder.DropTable(
                name: "LaibaryBooks");

            migrationBuilder.DropTable(
                name: "NotificationRoles");

            migrationBuilder.DropTable(
                name: "ParentSubervaisorChats");

            migrationBuilder.DropTable(
                name: "Reinforcementlessons");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropTable(
                name: "StudentAttendances");

            migrationBuilder.DropTable(
                name: "StudentDegrees");

            migrationBuilder.DropTable(
                name: "StudentSuggestions");

            migrationBuilder.DropTable(
                name: "StudentTimeTables");

            migrationBuilder.DropTable(
                name: "SubervisorNotifications");

            migrationBuilder.DropTable(
                name: "TeacherAnswers");

            migrationBuilder.DropTable(
                name: "TeacherAttendances");

            migrationBuilder.DropTable(
                name: "TeacherEvaluations");

            migrationBuilder.DropTable(
                name: "TeacherNotifications");

            migrationBuilder.DropTable(
                name: "TeacherTimeTables");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "HomeWorks");

            migrationBuilder.DropTable(
                name: "DegreeTypes");

            migrationBuilder.DropTable(
                name: "StudentQeustions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectClasses");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
