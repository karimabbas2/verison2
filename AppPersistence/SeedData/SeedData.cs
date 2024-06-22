

using AppDomain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppPersistence.SeedData
{
    public class SeedData(ModelBuilder modelBuilder)
    {
        private readonly ModelBuilder _modelBuilder = modelBuilder;


        //Method to call in DBContext
        public static SeedData Build(ModelBuilder modelBuilder)
        {
            return new SeedData(modelBuilder);
        }

        public void Seed()
        {
            DTMF();
            JitterBuffer();
            Privilege();
            var all = Codec();
            GlobalSetting(all);
            Departments();
            AdminUser();
            SIPSetting();
        }

        private void AdminUser()
        {
            const string ADMIN_USER_ID = "22e40406-8a9d";
            var passwordHasher = new PasswordHasher<IdentityUser>();
            var hashedPassword = passwordHasher.HashPassword(null, "admin");

            var AdminUser = new IdentityUser()
            {
                Id = ADMIN_USER_ID,
                NormalizedUserName = "admin",
                UserName = "admin",
                Email = "FiberMe@admin.com",
                PasswordHash = hashedPassword,
            };
            _modelBuilder.Entity<IdentityUser>().HasData(AdminUser);
        }

        private void DTMF()
        {
            var DTMFS = new List<DTMF>([
                new(){
                    Id =1,
                    DTMF_Mode="rfc4733"
                },
                new(){
                    Id =2,
                    DTMF_Mode="info"
                },
                new(){
                    Id=3,
                    DTMF_Mode="inband"
                },
                new(){
                    Id =4,
                    DTMF_Mode="rfc4733_info"
                },
                new(){
                    Id =5,
                    DTMF_Mode="auto"
                },
            ]);

            _modelBuilder.Entity<DTMF>().HasData(DTMFS);
        }

        private void JitterBuffer()
        {
            var JitterBuffers = new List<JitterBuffer>
              {
                  new() {Id=1, JitterBuffer_Name = "disable" },
                  new() {Id=2, JitterBuffer_Name = "fixed" },
                  new() {Id=3, JitterBuffer_Name = "adaptive" },
                  new() {Id=4, JitterBuffer_Name = "neteq" }
              };

            _modelBuilder.Entity<JitterBuffer>().HasData(JitterBuffers);

        }

        private void Privilege()
        {
            var Privileges = new List<Privilege>{
                new() {Id=1,Privilege_Name="internal"},
                new() {Id=2,Privilege_Name="local"},
                new() {Id=3,Privilege_Name="national"},
                new() {Id=4,Privilege_Name="international"},
            };

            _modelBuilder.Entity<Privilege>().HasData(Privileges);
        }

        private List<Codec> Codec()
        {

            var Codecs = new List<Codec>(){
                new(){Id=1,Codec_Name="alaw"},
                new(){Id=2,Codec_Name="ulaw"},
                new(){Id=3,Codec_Name="speex"},
                new(){Id=4,Codec_Name="gsm"},
                new(){Id=5,Codec_Name="opus"},
                new(){Id=6,Codec_Name="g722"},
                // new(){Id=7,Codec_Name="silk"},
                new(){Id=8,Codec_Name="g729"},
                new(){Id=9,Codec_Name="g723"},
                new(){Id=10,Codec_Name="g719"}
            };
            _modelBuilder.Entity<Codec>().HasData(Codecs);
            return Codecs;

        }

        private void GlobalSetting(List<Codec> codecs)
        {
            List<string> CodecFromInial = [];
            foreach (var item in codecs)
            {
                CodecFromInial.Add(item.Codec_Name);
            }

            var defaults = new GlobalExtenstionDefault()
            {
                Id = 1,
                Enable_NAT = false,
                Enable_VM = false,
                Sync_Contact = false,
                Ext_CC_Registrations = 3,
                Ext_DTMF = 1,
                Ext_Privilege = 1,
                Ext_Ring_Time = 60,
                JitterBuffer = 1,
                CodecFrom = string.Join(",", CodecFromInial),
                CodecTo = ""
            };
            _modelBuilder.Entity<GlobalExtenstionDefault>().HasData(defaults);
        }

        private void Departments()
        {
            var dept = new Department()
            {
                Id = 1,
                Dept_name = " "
            };
            _modelBuilder.Entity<Department>().HasData(dept);
        }

        private void SIPSetting()
        {
            var sipsetting = new SIPSetting()
            {
                Id = 1,
                UDP_PORT = 5060,
                TCP_PORT = 5060,
                TLS_PORT = 5162,
                RTP_Range_From = 10000,
                RTP_Range_TO = 20000,
            };
            _modelBuilder.Entity<SIPSetting>().HasData(sipsetting);

        }

    }
}