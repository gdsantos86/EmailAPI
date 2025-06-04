# EmailAPI

Um projeto exemplo de implementação de API para envio de emails utilizando .NET Core, demonstrando como criar um serviço robusto de email com templates HTML personalizáveis.

## 📋 Sobre o Projeto

Este projeto demonstra como criar uma API para envio de emails utilizando .NET Core, implementando configurações SMTP, templates HTML e seguindo as boas práticas de desenvolvimento de APIs RESTful.

## 🚀 Funcionalidades

- API para envio de emails via SMTP
- Sistema de templates HTML personalizáveis
- Configuração flexível de provedores de email
- Validação de dados de entrada
- Tratamento de erros e logs
- Estrutura de serviços organizados
- Templates para diferentes tipos de email (conclusão de pedido, confirmação de conta, etc.)

## 🛠️ Tecnologias Utilizadas

- **C#** - Linguagem de programação
- **ASP.NET Core Web API** - Framework para APIs
- **.NET Core** - Plataforma de desenvolvimento
- **SMTP** - Protocolo para envio de emails
- **HTML Templates** - Templates personalizáveis para emails
- **Dependency Injection** - Injeção de dependência nativa do .NET Core

## 📁 Estrutura do Projeto

```
EmailAPI/
├── Configuration/              # Configurações da aplicação
│   └── EmailSettings.cs
├── Controllers/               # Controladores da API
│   └── EmailController.cs
├── Models/                    # Modelos de dados
│   ├── EmailData.cs
│   └── EmailPara.cs
├── Properties/                # Propriedades do projeto
│   └── launchSettings.json
├── Services/                  # Serviços da aplicação
│   ├── EmailService.cs
│   └── IEmailService.cs
├── Templates/                 # Templates HTML para emails
│   ├── ConclusaoPedido.html
│   └── ConfirmacaoConta.html
├── appsettings.json          # Configurações da aplicação
├── appsettings.Development.json # Configurações de desenvolvimento
├── EmailAPI.csproj           # Arquivo do projeto
├── EmailAPI.sln              # Solution do projeto
├── Program.cs                # Ponto de entrada da aplicação
└── README.md                 # Documentação do projeto
```

## ⚙️ Pré-requisitos

- .NET 6.0 ou superior
- Visual Studio 2022 ou Visual Studio Code
- Conta de email SMTP (Gmail, Outlook, SendGrid, etc.)
- Postman ou ferramenta similar para testes de API (opcional)

## 🔧 Instalação e Configuração

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/gdsantos86/EmailAPI.git
   ```

2. **Navegue até o diretório do projeto:**
   ```bash
   cd EmailAPI
   ```

3. **Restaure as dependências:**
   ```bash
   dotnet restore
   ```

4. **Configure as credenciais de email:**
   - Edite o arquivo `appsettings.json`
   - Configure as informações do servidor SMTP:
   ```json
   {
     "EmailSettings": {
       "Host": "smtp.gmail.com",
       "Port": 587,
       "Username": "seu-email@gmail.com",
       "Password": "sua-senha-de-app",
       "FromEmail": "seu-email@gmail.com",
       "FromName": "Seu Nome"
     }
   }
   ```

5. **Execute a aplicação:**
   ```bash
   dotnet run
   ```

## 🎯 Como Usar

### Endpoints Disponíveis

#### Envio de Email
- `POST /api/email/send` - Envia email simples
- `POST /api/email/send-template` - Envia email com template HTML

### Exemplo de Uso

**Enviar email simples:**
```json
POST /api/email/send
{
  "to": "destinatario@email.com",
  "subject": "Assunto do Email",
  "body": "Conteúdo do email",
  "isHtml": false
}
```

**Enviar email com template:**
```json
POST /api/email/send-template
{
  "to": "destinatario@email.com",
  "subject": "Confirmação de Conta",
  "templateName": "ConfirmacaoConta",
  "templateData": {
    "nomeUsuario": "João Silva",
    "linkConfirmacao": "https://seusite.com/confirmar/123"
  }
}
```

### Templates Disponíveis

O projeto inclui templates HTML para:
- **ConclusaoPedido.html** - Email de confirmação de pedido
- **ConfirmacaoConta.html** - Email de confirmação de conta

### Configuração SMTP

Suporte para diferentes provedores:

**Gmail:**
- Host: smtp.gmail.com
- Port: 587
- Requer senha de app (não a senha normal)

**Outlook/Hotmail:**
- Host: smtp-mail.outlook.com
- Port: 587

**SendGrid:**
- Host: smtp.sendgrid.net
- Port: 587

## 🔒 Segurança

- Nunca commite credenciais no código
- Use variáveis de ambiente para informações sensíveis
- Configure senhas de aplicativo para Gmail
- Implemente rate limiting para prevenir spam

## 📖 Exemplo Prático

Este projeto demonstra:

- Como configurar um serviço de email em .NET Core
- Implementação de templates HTML dinâmicos
- Configuração de diferentes provedores SMTP
- Validação e tratamento de erros
- Injeção de dependência para serviços
- Estruturação de projetos de API

## 🤝 Contribuindo

Contribuições são sempre bem-vindas! Para contribuir:

1. Faça um Fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está disponível sob a Licença MIT para uso livre como exemplo e referência. 
Sinta-se à vontade para usar, modificar e aprender com o código.

## 👤 Autor

**Gustavo Santos** - [@gdsantos86](https://github.com/gdsantos86)

## 📞 Suporte

Se você tiver alguma dúvida ou sugestão, fique à vontade para:
- Abrir uma [Issue](https://github.com/gdsantos86/EmailAPI/issues)
- Entrar em contato através do GitHub

## 🔗 Links Úteis

- [Documentação ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
- [System.Net.Mail Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.net.mail)
- [Gmail App Passwords](https://support.google.com/accounts/answer/185833)

---

⭐ Se este projeto foi útil para você, considere dar uma estrela no repositório!
