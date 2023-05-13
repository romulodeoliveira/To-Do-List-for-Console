<div align="center">
    <h1>To Do List para Console</h1>
</div>

Um simples aplicativo de gerenciamento de tarefas para terminal com C# onde apliquei conceitos como princípio da responsabilidade única, a separação de preocupações e o padrão de desenvolvimento repository.

Se você quiser testar este app na sua máquina, você precisa ter instalado o .net 6.0. Basta navegar ao diretório da aplciação e executar no terminal o comando `dotnet run`. Mas caso queira integrá-lo ao sistema, você pode transferir o diretório da aplicação para qualquer parte do seu sistema e no arquivo de configuração do seu console (seja bash, ou zsh) verificar se há uma condição parecida com esta:

```zsh
# Definições pessoais de Alias para o sistema:
if [ -f ~/.zsh_aliases ]; then
    . ~/.zsh_aliases
fi
```

Caso haja, abra o arquivo `~/.zsh_aliases` ou `~/.bash_aliases` (dependendo de qual dos dois você usa). Pode executar o comando `gedit ~/.zsh_aliases`. Com o arquivo de configuração aberto, insira a seguinte linha de código:

```zsh
# ToDoList
alias todolist='dotnet run --project /caminho/do/diretório/do/projeto'
```

Execute `reboot` e seja feliz. :)

<div align="center">
    <img src="https://github.com/romulodeoliveira/To-Do-List-for-Console/blob/main/img/img1.gif">
</div>
