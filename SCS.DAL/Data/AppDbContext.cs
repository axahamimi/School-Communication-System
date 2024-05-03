using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SCS.DAL.Entites;

namespace SCS.DAL.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassChat> ClassChats { get; set; }

    public virtual DbSet<DegreeFile> DegreeFiles { get; set; }

    public virtual DbSet<DegreeType> DegreeTypes { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<FollowUpNoteBook> FollowUpNoteBooks { get; set; }

    public virtual DbSet<HomeWork> HomeWorks { get; set; }

    public virtual DbSet<LaibaryBook> LaibaryBooks { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationRole> NotificationRoles { get; set; }

    public virtual DbSet<ParentSubervaisorChat> ParentSubervaisorChats { get; set; }

    public virtual DbSet<Reinforcementlesson> Reinforcementlessons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Solution> Solutions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

    public virtual DbSet<StudentDegree> StudentDegrees { get; set; }

    public virtual DbSet<StudentQeustion> StudentQeustions { get; set; }

    public virtual DbSet<StudentSuggestion> StudentSuggestions { get; set; }

    public virtual DbSet<StudentTimeTable> StudentTimeTables { get; set; }

    public virtual DbSet<SubervisorNotification> SubervisorNotifications { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectClass> SubjectClasses { get; set; }

    public virtual DbSet<TeacherAnswer> TeacherAnswers { get; set; }

    public virtual DbSet<TeacherAttendance> TeacherAttendances { get; set; }

    public virtual DbSet<TeacherEvaluation> TeacherEvaluations { get; set; }

    public virtual DbSet<TeacherNotification> TeacherNotifications { get; set; }

    public virtual DbSet<TeacherTimeTable> TeacherTimeTables { get; set; }

    public virtual DbSet<Term> Terms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VclassDegree> VclassDegrees { get; set; }

    public virtual DbSet<VclassSubjectDegree> VclassSubjectDegrees { get; set; }

    public virtual DbSet<VclassSubjectTermDegree> VclassSubjectTermDegrees { get; set; }

    public virtual DbSet<VclassTermDegree> VclassTermDegrees { get; set; }

    public virtual DbSet<VteacherEvalution> VteacherEvalutions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = LAPTOP-2AR5OF7M ; Initial Catalog = SCA11 ; Integrated Security =SSPI ;TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927C0A43DC339");

            entity.Property(e => e.ClassName).HasMaxLength(255);

            entity.HasOne(d => d.ClassSopervisorNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.ClassSopervisor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__ClassSo__440B1D61");

            entity.HasOne(d => d.Level).WithMany(p => p.Classes)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__LevelId__4316F928");
        });

        modelBuilder.Entity<ClassChat>(entity =>
        {
            entity.HasKey(e => e.ClassChatId).HasName("PK__ClassCha__366737B7853C99E7");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassChats)
                .HasForeignKey(d => d.Classid)
                .HasConstraintName("FK__ClassChat__Class__0F624AF8");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassChats)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__ClassChat__Stude__10566F31");
        });

        modelBuilder.Entity<DegreeFile>(entity =>
        {
            entity.HasKey(e => e.DegreeFileId).HasName("PK__DegreeFi__BE204451D78EA090");

            entity.Property(e => e.DegreeFileName).HasMaxLength(255);

            entity.HasOne(d => d.DegreeType).WithMany(p => p.DegreeFiles)
                .HasForeignKey(d => d.DegreeTypeId)
                .HasConstraintName("FK__DegreeFil__Degre__619B8048");

            entity.HasOne(d => d.Student).WithMany(p => p.DegreeFiles)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__DegreeFil__Stude__628FA481");

            entity.HasOne(d => d.Term).WithMany(p => p.DegreeFiles)
                .HasForeignKey(d => d.TermId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DegreeFil__TermI__60A75C0F");
        });

        modelBuilder.Entity<DegreeType>(entity =>
        {
            entity.HasKey(e => e.DegreeTypeId).HasName("PK__DegreeTy__DD0FA03F989A78C7");

            entity.Property(e => e.DegreeTypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED2D6C38DB");

            entity.Property(e => e.DepartmentName).HasMaxLength(255);
        });

        modelBuilder.Entity<FollowUpNoteBook>(entity =>
        {
            entity.HasKey(e => e.FollowUpNoteBookId).HasName("PK__FollowUp__64828509BE018E62");

            entity.HasOne(d => d.Class).WithMany(p => p.FollowUpNoteBooks)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FollowUpN__Class__75A278F5");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.FollowUpNoteBooks)
                .HasForeignKey(d => d.SubjectClassId)
                .HasConstraintName("FK__FollowUpN__Subje__74AE54BC");

            entity.HasOne(d => d.Term).WithMany(p => p.FollowUpNoteBooks)
                .HasForeignKey(d => d.TermId)
                .HasConstraintName("FK__FollowUpN__TermI__76969D2E");
        });

        modelBuilder.Entity<HomeWork>(entity =>
        {
            entity.HasKey(e => e.HomeWorkId).HasName("PK__HomeWork__C49C7058C45406AA");

            entity.Property(e => e.HomeWorkDegree).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.HomeWorkTitle).HasMaxLength(255);

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.HomeWorks)
                .HasForeignKey(d => d.SubjectClassId)
                .HasConstraintName("FK__HomeWorks__Subje__656C112C");

            entity.HasOne(d => d.Term).WithMany(p => p.HomeWorks)
                .HasForeignKey(d => d.TermId)
                .HasConstraintName("FK__HomeWorks__TermI__66603565");
        });

        modelBuilder.Entity<LaibaryBook>(entity =>
        {
            entity.HasKey(e => e.LaibaryBookId).HasName("PK__LaibaryB__FC3D9298FAEF7CC5");

            entity.Property(e => e.LaibaryBookName).HasMaxLength(255);

            entity.HasOne(d => d.Section).WithMany(p => p.LaibaryBooks)
                .HasForeignKey(d => d.Sectionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LaibaryBo__Secti__0C85DE4D");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__Levels__09F03C26DD3AFEE2");

            entity.Property(e => e.LevelName).HasMaxLength(255);

            entity.HasOne(d => d.Department).WithMany(p => p.Levels)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Levels__Departme__403A8C7D");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E12C5C02ECF");

            entity.Property(e => e.NotificationTitle).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__17036CC0");
        });

        modelBuilder.Entity<NotificationRole>(entity =>
        {
            entity.HasKey(e => e.NotificationRoleId).HasName("PK__Notifica__D523AA9054D92CD0");

            entity.Property(e => e.NotificationRoleName).HasMaxLength(255);

            entity.HasOne(d => d.Notification).WithMany(p => p.NotificationRoles)
                .HasForeignKey(d => d.NotificationId)
                .HasConstraintName("FK__Notificat__Notif__19DFD96B");

            entity.HasOne(d => d.Role).WithMany(p => p.NotificationRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Notificat__RoleI__1AD3FDA4");
        });

        modelBuilder.Entity<ParentSubervaisorChat>(entity =>
        {
            entity.HasKey(e => e.ParentSubervaisorChatId).HasName("PK__ParentSu__5CE078C8914C6D9B");

            entity.HasOne(d => d.ReceverNavigation).WithMany(p => p.ParentSubervaisorChatReceverNavigations)
                .HasForeignKey(d => d.Recever)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ParentSub__Recev__14270015");

            entity.HasOne(d => d.SenderNavigation).WithMany(p => p.ParentSubervaisorChatSenderNavigations)
                .HasForeignKey(d => d.Sender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ParentSub__Sende__1332DBDC");
        });

        modelBuilder.Entity<Reinforcementlesson>(entity =>
        {
            entity.HasKey(e => e.ReinforcementlessonId).HasName("PK__Reinforc__B162A1F24B334BFB");

            entity.Property(e => e.ReinforcementlessonTitle).HasMaxLength(255);

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.Reinforcementlessons)
                .HasForeignKey(d => d.SubjectClassId)
                .HasConstraintName("FK__Reinforce__Subje__7D439ABD");

            entity.HasOne(d => d.Term).WithMany(p => p.Reinforcementlessons)
                .HasForeignKey(d => d.TermId)
                .HasConstraintName("FK__Reinforce__TermI__7E37BEF6");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AB92E2539");

            entity.Property(e => e.RoleName).HasMaxLength(255);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Sections__80EF0872CDC94C33");

            entity.Property(e => e.SectionName).HasMaxLength(255);
        });

        modelBuilder.Entity<Solution>(entity =>
        {
            entity.HasKey(e => e.SolutionId).HasName("PK__Solution__6B633AD08345CAC6");

            entity.Property(e => e.SolutionDegree).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.HomeWork).WithMany(p => p.Solutions)
                .HasForeignKey(d => d.HomeWorkId)
                .HasConstraintName("FK__Solutions__HomeW__693CA210");

            entity.HasOne(d => d.Student).WithMany(p => p.Solutions)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Solutions__Stude__6A30C649");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B991EF14DA2");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__ClassI__5070F446");

            entity.HasOne(d => d.StedentParentNavigation).WithMany(p => p.StudentStedentParentNavigations)
                .HasForeignKey(d => d.StedentParent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__Steden__4F7CD00D");

            entity.HasOne(d => d.User).WithMany(p => p.StudentUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Students__UserId__4E88ABD4");
        });

        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.HasKey(e => e.StudentAttendanceId).HasName("PK__StudentA__6342645B998B6F8C");

            entity.Property(e => e.StudentAttendanceValue).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAttendances)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentAt__Stude__01142BA1");

            entity.HasOne(d => d.Term).WithMany(p => p.StudentAttendances)
                .HasForeignKey(d => d.TermId)
                .HasConstraintName("FK__StudentAt__TermI__02084FDA");
        });

        modelBuilder.Entity<StudentDegree>(entity =>
        {
            entity.HasKey(e => e.StudentDegreeId).HasName("PK__StudentD__0CC89BAD4CA02FF8");

            entity.Property(e => e.StudentDegreeValue).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.DegreeType).WithMany(p => p.StudentDegrees)
                .HasForeignKey(d => d.DegreeTypeId)
                .HasConstraintName("FK__StudentDe__Degre__5DCAEF64");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentDegrees)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentDe__Stude__5BE2A6F2");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.StudentDegrees)
                .HasForeignKey(d => d.SubjectClassId)
                .HasConstraintName("FK__StudentDe__Subje__5AEE82B9");

            entity.HasOne(d => d.Term).WithMany(p => p.StudentDegrees)
                .HasForeignKey(d => d.TermId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentDe__TermI__5CD6CB2B");
        });

        modelBuilder.Entity<StudentQeustion>(entity =>
        {
            entity.HasKey(e => e.StudentQeustionId).HasName("PK__StudentQ__A171725E580C4668");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentQeustions)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentQe__Stude__6E01572D");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.StudentQeustions)
                .HasForeignKey(d => d.SubjectClassId)
                .HasConstraintName("FK__StudentQe__Subje__6D0D32F4");

            entity.HasOne(d => d.Term).WithMany(p => p.StudentQeustions)
                .HasForeignKey(d => d.TermId)
                .HasConstraintName("FK__StudentQe__TermI__6EF57B66");
        });

        modelBuilder.Entity<StudentSuggestion>(entity =>
        {
            entity.HasKey(e => e.StudentSuggestionId).HasName("PK__StudentS__699998993E593C88");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentSuggestions)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__StudentSu__Class__7A672E12");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentSuggestions)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentSu__Stude__797309D9");
        });

        modelBuilder.Entity<StudentTimeTable>(entity =>
        {
            entity.HasKey(e => e.StudentTimeTableId).HasName("PK__StudentT__AA15A797DF37C1F4");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentTimeTables)
                .HasForeignKey(d => d.Classid)
                .HasConstraintName("FK__StudentTi__Class__534D60F1");
        });

        modelBuilder.Entity<SubervisorNotification>(entity =>
        {
            entity.HasKey(e => e.SubervisorNotificationId).HasName("PK__Subervis__C7602C358A7AD4E2");

            entity.HasOne(d => d.Class).WithMany(p => p.SubervisorNotifications)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Suberviso__Class__22751F6C");

            entity.HasOne(d => d.Notification).WithMany(p => p.SubervisorNotifications)
                .HasForeignKey(d => d.NotificationId)
                .HasConstraintName("FK__Suberviso__Notif__2180FB33");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3A827384BB8");

            entity.Property(e => e.SubjectBook1).HasMaxLength(255);
            entity.Property(e => e.SubjectBook2).HasMaxLength(255);
            entity.Property(e => e.SubjectBook3).HasMaxLength(255);
            entity.Property(e => e.SubjectName).HasMaxLength(255);

            entity.HasOne(d => d.Level).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subjects__LevelI__46E78A0C");
        });

        modelBuilder.Entity<SubjectClass>(entity =>
        {
            entity.HasKey(e => e.SubjectClassId).HasName("PK__SubjectC__56E2859A3B35A6C6");

            entity.Property(e => e.SubjectClassName).HasMaxLength(255);

            entity.HasOne(d => d.Class).WithMany(p => p.SubjectClasses)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__SubjectCl__Class__49C3F6B7");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectClasses)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubjectCl__Subje__4AB81AF0");

            entity.HasOne(d => d.SubjectTeacherNavigation).WithMany(p => p.SubjectClasses)
                .HasForeignKey(d => d.SubjectTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubjectCl__Subje__4BAC3F29");
        });

        modelBuilder.Entity<TeacherAnswer>(entity =>
        {
            entity.HasKey(e => e.TeacherAnswerId).HasName("PK__TeacherA__A3B38DF996FAA0AC");

            entity.HasOne(d => d.StudentQeustion).WithMany(p => p.TeacherAnswers)
                .HasForeignKey(d => d.StudentQeustionId)
                .HasConstraintName("FK__TeacherAn__Stude__71D1E811");
        });

        modelBuilder.Entity<TeacherAttendance>(entity =>
        {
            entity.HasKey(e => e.TeacherAttendanceId).HasName("PK__TeacherA__678A48105127EB87");

            entity.Property(e => e.TeacherAttendanceValue).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.TeacherAttendances)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TeacherAt__UserI__07C12930");
        });

        modelBuilder.Entity<TeacherEvaluation>(entity =>
        {
            entity.HasKey(e => e.TeacherEvaluationId).HasName("PK__TeacherE__0F0C6E4734850A4E");

            entity.Property(e => e.TeacherEvaluationValue).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TeacherEvaluationValueTow).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.TeacherEvaluations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TeacherEv__UserI__04E4BC85");
        });

        modelBuilder.Entity<TeacherNotification>(entity =>
        {
            entity.HasKey(e => e.TeacherNotificationId).HasName("PK__TeacherN__2AF3B401732B9ACC");

            entity.HasOne(d => d.Notification).WithMany(p => p.TeacherNotifications)
                .HasForeignKey(d => d.NotificationId)
                .HasConstraintName("FK__TeacherNo__Notif__1DB06A4F");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.TeacherNotifications)
                .HasForeignKey(d => d.SubjectClassId)
                .HasConstraintName("FK__TeacherNo__Subje__1EA48E88");
        });

        modelBuilder.Entity<TeacherTimeTable>(entity =>
        {
            entity.HasKey(e => e.TeacherTimeTableId).HasName("PK__TeacherT__466F62C46668223E");

            entity.HasOne(d => d.User).WithMany(p => p.TeacherTimeTables)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TeacherTi__UserI__5629CD9C");
        });

        modelBuilder.Entity<Term>(entity =>
        {
            entity.HasKey(e => e.TermId).HasName("PK__Terms__410A21A58BFEAF71");

            entity.Property(e => e.TermName).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C467C8E13");

            entity.Property(e => e.UserName).HasMaxLength(255);
            entity.Property(e => e.Usernumber).HasMaxLength(20);
            entity.Property(e => e.Userpassword).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__398D8EEE");
        });

        modelBuilder.Entity<VclassDegree>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VClassDegrees");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.StudentName).HasMaxLength(255);
            entity.Property(e => e.TotalMarks).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<VclassSubjectDegree>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VClassSubjectDegrees");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.StudentName).HasMaxLength(255);
            entity.Property(e => e.SubjectClassName).HasMaxLength(255);
            entity.Property(e => e.TotalMarks).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<VclassSubjectTermDegree>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VClassSubjectTermDegrees");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.StudentName).HasMaxLength(255);
            entity.Property(e => e.SubjectClassName).HasMaxLength(255);
            entity.Property(e => e.TermName).HasMaxLength(255);
            entity.Property(e => e.TotalMarks).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<VclassTermDegree>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VClassTermDegrees");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.StudentName).HasMaxLength(255);
            entity.Property(e => e.TermName).HasMaxLength(255);
            entity.Property(e => e.TotalMarks).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<VteacherEvalution>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VTeacherEvalutions");

            entity.Property(e => e.TeacherEvaluationValue).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TeacherEvaluationValueTow).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TeacherName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
