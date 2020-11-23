using System.IO;

namespace Locadora_Ary.Navegacao
{
    class Login
    {
        //Entrada de dados para login (username e senha)
        public string Username { get; set; }
        public int Senha { get; set; }

        public Login()
        {
        }

        public Login(string username, int senha)
        {
            Username = username;
            Senha = senha;
        }

        //Verificando o usuário (o username e a senha)
        public bool VerificaUsuario(string username,int senha)
        {
            
            string path = @"C:\Users\Administrador\source\repos\Locadora_Ary\Usuario_senha.txt";
            StreamReader sr = File.OpenText(path);
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(',');
                string username2 = line[0];
                int senha2 = int.Parse(line[1]);
                if (username == username2 && senha == senha2)
                {
                    return true;
                }
            }
            return false;
        }
      
    }
}
