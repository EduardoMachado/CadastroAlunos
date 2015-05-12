using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroAlunos.Models;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;

namespace CadastroAlunos.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        //string conexao = "Server=tcp:homdevops.cloudapp.net,1433;Database=Pessoa;User ID=sa;Password=!@#Bandtec;Trusted_Connection=False;Encrypt=True;Connection Timeout=30; providerName="System.Data.EntityClient";
        

        public ActionResult Cadastrar()
        {

            return View();
        }

        public ActionResult Index() 
        {            
            
            string comando = "SELECT * FROM Aluno";
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(comando, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Aluno> ListaAlunos = new List<Aluno>();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Aluno a = new Aluno();
                    a.Id = int.Parse(dr[0].ToString());
                    a.Nome = dr[1].ToString();
                    a.NomePai = dr[2].ToString();
                    a.NomeMae = dr[3].ToString();
                    a.Rg = dr[4].ToString();
                    a.Cpf = dr[5].ToString();
                    a.Rua = dr[6].ToString();
                    a.Numero = dr[7].ToString();
                    a.Complemento = dr[8].ToString();
                    a.Bairro = dr[9].ToString();
                    a.Cidade = dr[10].ToString();
                    a.Estado = dr[11].ToString();
                    a.Cep = dr[12].ToString();
                    a.Email = dr[13].ToString();
                    a.Ra = dr[14].ToString();
                    a.Curso = dr[15].ToString();
                    a.Semestre = dr[16].ToString();
                    a.Periodo = dr[17].ToString();
                    a.DtCadastro = Convert.ToDateTime(dr[18].ToString());
                    a.Usuario = dr[19].ToString();
                    a.Senha = dr[20].ToString();
                    ListaAlunos.Add(a);
                }
            }


            conn.Close();
            return View(ListaAlunos);
           
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string comando = "INSERT INTO ALUNO VALUES (@Nome, @NomePai, @NomeMae ,@Rg, @Cpf, @Rua, @Numero,"+
                             "@Complemento, @Bairro, @Cidade, @Estado, @Cep, @Email, @Ra, @Curso, @Semestre," +
                             "@Periodo, @DtCadastro, @Usuario, @Senha)";
            SqlCommand cmd = new SqlCommand(comando,conn);
            cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@NomePai", aluno.NomePai);
            cmd.Parameters.AddWithValue("@NomeMae", aluno.NomeMae);
            cmd.Parameters.AddWithValue("@Rg", aluno.Rg);
            cmd.Parameters.AddWithValue("@Cpf", aluno.Cpf);
            cmd.Parameters.AddWithValue("@Rua", aluno.Rua);
            cmd.Parameters.AddWithValue("@Numero", aluno.Numero);
            cmd.Parameters.AddWithValue("@Complemento", aluno.Complemento);
            cmd.Parameters.AddWithValue("@Bairro", aluno.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", aluno.Cidade);
            cmd.Parameters.AddWithValue("@Estado", aluno.Estado);
            cmd.Parameters.AddWithValue("@Cep", aluno.Cep);
            cmd.Parameters.AddWithValue("@Email", aluno.Email);
            cmd.Parameters.AddWithValue("@Ra", aluno.Ra);
            cmd.Parameters.AddWithValue("@Curso", aluno.Curso);
            cmd.Parameters.AddWithValue("@Semestre", aluno.Semestre);
            cmd.Parameters.AddWithValue("@Periodo", aluno.Periodo);
            cmd.Parameters.AddWithValue("@DtCadastro", aluno.DtCadastro);
            cmd.Parameters.AddWithValue("@Usuario", "");
            cmd.Parameters.AddWithValue("@Senha", "");

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("Index");
           
        }
        
        public ActionResult Detalhes(int id)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string comando = "SELECT * FROM ALUNO WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(comando,conn);
            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();            
            SqlDataReader dr = cmd.ExecuteReader();
            Aluno a = new Aluno();
           
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    a.Id = int.Parse(dr[0].ToString());
                    a.Nome = dr[1].ToString();
                    a.NomePai = dr[2].ToString();
                    a.NomeMae = dr[3].ToString();
                    a.Rg = dr[4].ToString();
                    a.Cpf = dr[5].ToString();
                    a.Rua = dr[6].ToString();
                    a.Numero = dr[7].ToString();
                    a.Complemento = dr[8].ToString();
                    a.Bairro = dr[9].ToString();
                    a.Cidade = dr[10].ToString();
                    a.Estado = dr[11].ToString();
                    a.Cep = dr[12].ToString();
                    a.Email = dr[13].ToString();
                    a.Ra = dr[14].ToString();
                    a.Curso = dr[15].ToString();
                    a.Semestre = dr[16].ToString();
                    a.Periodo = dr[17].ToString();
                    a.DtCadastro = Convert.ToDateTime(dr[18].ToString());
                    a.Usuario = dr[19].ToString();
                    a.Senha = dr[20].ToString();
                    
                }
                
           }

            return View(a); 
        }

        [HttpPost]
        public ActionResult Detalhes(Aluno aluno)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string comando = "UPDATE ALUNO SET Nome= @Nome, NomePai= @NomePai,NomeMae= @NomeMae ,Rg=@Rg,Cpf=@Cpf,Rua=@Rua,Numero=@Numero," +
                             "Complemento = @Complemento,Bairro= @Bairro,Cidade= @Cidade,Estado= @Estado,Cep= @Cep,Email= @Email,Ra= @Ra,Curso= @Curso,Semestre= @Semestre," +
                             "Periodo =@Periodo,DtCadastro= @DtCadastro,Usuario= @Usuario,Senha= @Senha WHERE Id = @Id ";
            SqlCommand cmd = new SqlCommand(comando, conn);
            cmd.Parameters.AddWithValue("@Id", aluno.Id);
            cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@NomePai", aluno.NomePai);
            cmd.Parameters.AddWithValue("@NomeMae", aluno.NomeMae);
            cmd.Parameters.AddWithValue("@Rg", aluno.Rg);
            cmd.Parameters.AddWithValue("@Cpf", aluno.Cpf);
            cmd.Parameters.AddWithValue("@Rua", aluno.Rua);
            cmd.Parameters.AddWithValue("@Numero", aluno.Numero);
            cmd.Parameters.AddWithValue("@Complemento", aluno.Complemento);
            cmd.Parameters.AddWithValue("@Bairro", aluno.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", aluno.Cidade);
            cmd.Parameters.AddWithValue("@Estado", aluno.Estado);
            cmd.Parameters.AddWithValue("@Cep", aluno.Cep);
            cmd.Parameters.AddWithValue("@Email", aluno.Email);
            cmd.Parameters.AddWithValue("@Ra", aluno.Ra);
            cmd.Parameters.AddWithValue("@Curso", aluno.Curso);
            cmd.Parameters.AddWithValue("@Semestre", aluno.Semestre);
            cmd.Parameters.AddWithValue("@Periodo", aluno.Periodo);
            cmd.Parameters.AddWithValue("@DtCadastro", aluno.DtCadastro);
            cmd.Parameters.AddWithValue("@Usuario", "");
            cmd.Parameters.AddWithValue("@Senha", "");

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string comando = "SELECT * FROM ALUNO WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(comando, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Aluno a = new Aluno();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    a.Id = int.Parse(dr[0].ToString());
                    a.Nome = dr[1].ToString();
                    a.NomePai = dr[2].ToString();
                    a.NomeMae = dr[3].ToString();
                    a.Rg = dr[4].ToString();
                    a.Cpf = dr[5].ToString();
                    a.Rua = dr[6].ToString();
                    a.Numero = dr[7].ToString();
                    a.Complemento = dr[8].ToString();
                    a.Bairro = dr[9].ToString();
                    a.Cidade = dr[10].ToString();
                    a.Estado = dr[11].ToString();
                    a.Cep = dr[12].ToString();
                    a.Email = dr[13].ToString();
                    a.Ra = dr[14].ToString();
                    a.Curso = dr[15].ToString();
                    a.Semestre = dr[16].ToString();
                    a.Periodo = dr[17].ToString();
                    a.DtCadastro = Convert.ToDateTime(dr[18].ToString());
                    a.Usuario = dr[19].ToString();
                    a.Senha = dr[20].ToString();

                }

            }

            return View(a);
        }

       [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {

            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string comando = "UPDATE ALUNO SET Nome= @Nome, NomePai= @NomePai,NomeMae= @NomeMae ,Rg=@Rg,Cpf=@Cpf,Rua=@Rua,Numero=@Numero," +
                             "Complemento = @Complemento,Bairro= @Bairro,Cidade= @Cidade,Estado= @Estado,Cep= @Cep,Email= @Email,Ra= @Ra,Curso= @Curso,Semestre= @Semestre," +
                             "Periodo =@Periodo,DtCadastro= @DtCadastro,Usuario= @Usuario,Senha= @Senha WHERE Id = @Id ";
            SqlCommand cmd = new SqlCommand(comando, conn);
            cmd.Parameters.AddWithValue("@Id", aluno.Id);
            cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@NomePai", aluno.NomePai);
            cmd.Parameters.AddWithValue("@NomeMae", aluno.NomeMae);
            cmd.Parameters.AddWithValue("@Rg", aluno.Rg);
            cmd.Parameters.AddWithValue("@Cpf", aluno.Cpf);
            cmd.Parameters.AddWithValue("@Rua", aluno.Rua);
            cmd.Parameters.AddWithValue("@Numero", aluno.Numero);
            cmd.Parameters.AddWithValue("@Complemento", aluno.Complemento);
            cmd.Parameters.AddWithValue("@Bairro", aluno.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", aluno.Cidade);
            cmd.Parameters.AddWithValue("@Estado", aluno.Estado);
            cmd.Parameters.AddWithValue("@Cep", aluno.Cep);
            cmd.Parameters.AddWithValue("@Email", aluno.Email);
            cmd.Parameters.AddWithValue("@Ra", aluno.Ra);
            cmd.Parameters.AddWithValue("@Curso", aluno.Curso);
            cmd.Parameters.AddWithValue("@Semestre", aluno.Semestre);
            cmd.Parameters.AddWithValue("@Periodo", aluno.Periodo);
            cmd.Parameters.AddWithValue("@DtCadastro", aluno.DtCadastro);
            cmd.Parameters.AddWithValue("@Usuario", "");
            cmd.Parameters.AddWithValue("@Senha", "");

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");
        }

       public ActionResult Excluir(int id)
       {
           SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
           string comando = "DELETE FROM ALUNO WHERE ID= @ID";
           SqlCommand cmd = new SqlCommand(comando, conn);
           cmd.Parameters.AddWithValue("@ID", id);

           conn.Open();
           cmd.ExecuteNonQuery();
           conn.Close();
           return RedirectToAction("Index");

       }

        [AllowAnonymous]
       public ActionResult LogOn()
       {
           return View();
       }
     
       [HttpPost]
       [AllowAnonymous]
       public ActionResult LogOn(Aluno a)
       {

           
           if (a.Usuario == "admin" && a.Senha == "admin")
           {
               FormsAuthentication.SetAuthCookie(a.Usuario, true);
               return RedirectToAction("Index");
           }
           else
           {
               return View();
           }
       }
    }
}
