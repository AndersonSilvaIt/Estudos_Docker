
## Curso de Docker  Desenvolvedor.IO

Para criar um novo container, atravéz de uma imagem já existente

### Criar um cointainer

**Imagem Nome:** `docker/welcome-to-docker:latest` <br/>
**Porta Interna:** `80`<br/>
**Porta Externa:** `8088`  `Acesso externo` <br/>
* *No caso das portas, primeiro preciso informar qual a porta que minha aplicação ficará disponível para acesso externo, depois informo qual a porta interna será mapeada* <br/>

`docker run --name NOME_CONTAINER -d -p PORTA NOME_IMAGEM` <br/>
*   `docker run --name meu-container -d -p 8088:80 docker/welcome-to-docker:latest`


### Iniciar um container

`docker start CONTAINER_NAME`<br/>
`docker start ID_CONTAINER`
*   `docker start meu-container`


### Interagir com um Container

`docker exec -it CONTAINER_NAME/ID /bin/bash` --> Executa um comando dentro do container informado
 > **/bash/sh**  ➜ ShellScript Womdows
 >
 > **/bin/bash** ➜ Sshell Linux
`
<br/>

* `docker exec -it meu-container /bin/sh`
* `docker logs CONTAINER`  ➜ Mostra os logs do container
* `docker inspect CONTAINER` ➜ Mostra os arquivos de dentro do container

* `docker cp CONTAINER_NAME:FILE_A_COPIAR DENSTINO_NOME`
    *  `docker cp meu-container:/usr/share/nginx/html/index.html c:\temp\index.html`
        > **meu-container** : Nome container
        >
        > **usr/share....index.html** : Arquivo que será copiado para a máquina local
        >
        > **c:temp....index.html** : Local em minha máquina que o arquivo será copiado, posso usar outro nome, "index2.html"  
        > **Obs**: Verificar se existe o caminho "c:/temp" primeiro, caso não existir, irá apresentar erro
* `more File_Name` ➜ Mostra o conteúdo de um arquivo

<br/>

#### Baixar uma imagem
* `docker pull IMAGE_NAME`
    >  docker pull mcr.microsoft.com/dotnet/nightly/runtime:9.0-preview

<br/>

### Trabalhando com imagens locais
* `docker images -a` ➜ Lista todas as imagens
* `docker save -o "d:\temp\myimage.tar" IMAGE_NAME/ID` ➜ Salva uma imagem <br/>
    * `docker save -o d:\temp\myimage.tar c1f619b6477e` 

* `docker load -i LOCAL_IMAGE `
    * `docker load -i d:\temp\myimage.tar`  ➜ Carrega uma imagem .tar para dentro do docker     

* `docker tag ID_IMAGE IMAGE_NAME:TAG` ➜ Altera o nome e a tag da imagem, passando o ID como parÂmetro
    *  `docker tag c1f619b6477e imagem-carregada:latest`

* `docker rmi ID/IMAGE_NAME` ➜ Remove uma imagem
    * `docker rmi c1f619b6477e`
* `docker image prune -a ` ➜ Exclui todas as imagens, mesmo as mesmas que estão sendo usadas por containers
    


## Redes

* `Rede Host` ➜ Rede da máquina em que o docker está sendo usado, o PC Físico digamos assim

* `Rede Interna` ➜ Rede do próprio docker

* `docker network ls` ➜ Lista as redes docker

* `docker network create --driver bridge minha-rede` ➜ Cria uma nova rede específica, onde somente os containers mapeado pra ela conseguirão se comunicar

* `docker run --name nginx2 --network minha-rede -d nginx` ➜ Configura o container para rodar em uma rede específica

* `docker network rm minharede` ➜ Remove uma rede 
    *   *Se existir containers com essa rede, irá apresentar um erro*

* `docker network inspect minha-rede` ➜ Inspeciona a rede, mostra os containers que estão usando essa rede

* `docker disconnect minha-rede nginx2` ➜ Remove o container **nginx2** da rede

* `docker network connect bridge nginx2` ➜ Conecta o container **nginx2** na rede **bridge**
    * *Eu posso ter um docker rodando em mais de uma rede, para isso, pasta rodar o commando **connect** novamente apontando para a outra rede*


### Volumes
 `Área de disco da máquina HOST reservada para o container, caso o  container seja deletado, esses dados não ficam perdidos`

`docker run -d -p 8080:80 --name nginx-demo -v d:\docker:/usr/share/nginx/html:ro nginx` <br/>
* *Criar o volume para a pasta c:\docker*

    * `-v` ➜ Comando para criar o volume<br/>
    * `d:\docker` ➜ Pasta no HOST que será o volume mapeado<br/>
    * `/usr/share/nginx/html` ➜ Pasta de dentro do container, que será mapeada para o volume externo (host)
    * `ro` ➜ Permissão do linux (no caso, somente leitura)

    

### Criar imagem através do Dockerfile  
* `docker build -t aspnet-app:latest .`
    * **`build`** ➜ Compila o Dockerfile
    * **`-t`** ➜ Comando para dar um nome para a imagem a ser criada
    * **`aspnet-app:latest`** ➜ O nome da imagem criadao
    * **`.`** ➜ Local onde está localizado o **Dockerfile**

* `Se atentar com os diretórios mapeados dentro do Dockerfile`


## Docker Compose

*  **`Projeto Exemplo`** ➜ `https://github.com/desenvolvedor-io/curso-angular-avancado/tree/master`

* **Pasta do arquivo a ser testado** ➜ `D:\Anderson\Estudos\Cursos\Curso_Docker\compose_exemplo`

* `docker compose up`
    * *Por padrão, esse comando busca pelo arquvo com nome "docker-compose.yml", ou então, se eu não estiver na mesma pasta do arquido compose, caso  contrário, é necessário passar o nome completo do arquivo "docker compose -f docker-compose-xpto.yml"* 

* `docker compose -p teste up` ➜ Criar o compose agrupado pelo nome **Teste*

### Comandos Úteis

| Command           | Description                                           |
| --------               | ---                                                   |
| `-d`              | Desatacha o prompt de comando, se eu rodar um comando para criar o docker por exemplo, ele me libera o terminal para fazer outra coisa |
| `-p`        | Informa em qual porta o docker estará rodando |
| `--name`    | Informa um nome para o container a ser criado |
| `start`     | Inicia um container existente|
| `ps`        | Lista os dockers em execução |
| `-a`        | Lista todos os dockers, em execução ou não |
| `rm`        | Deleta os containers em execução |
| `prune`     | Deleta os contaners que estão parados |
| `stats`     | Obtém os status dos containers |
| `exec`      | Executa um comando dentro do container |
| `-it `      | Modo "iterativo", o que acontecer no terminal do container, irá mostrar no terminal atual |
| `exit`      | Sai do terminal do container e volta para o terminal de sua máquina|
| `logs`      | Mostra os logs do container |
| `inspect`   | Inspeciona os arquivos do docker |
| `cp`        | Copiar algum arquivo do docker para a máquina local|
| `more`      | Mostra o conteúdo de um arquivo do container|
| `pull `     | Faz o download de uma imagem |
| `images`    | Lista as imagens disponíveis |
| `-a`        | Lista as imagens pendentes, sem versão e etc. |
| `save`      | Salva uma imagem |
| `-o`        | Output, por exemplo ao salvar uma imagem (save -o joga o arquivo para tal lugar) |
| `load`      | Carrega uma imagem local, por exemplo se alguém te enviar o arquivo .tar|
| `-i`        | Import, importa uma imagem local |
| `tag`       | Define uma tag para a imagem, também já definido um nome da imagem nesse momento |
| `rmi`       | Remover uma imagem |
| `image prune -a` | Remove todas as imagens |
| `network ls`| Lista as redes docker |
| `-v`        | Cria um volume  |
| `-t`        | Dá um nome para a imagem, quando criada pelo dockerfile
| `-f`        | File, ex: `docker compose -f docker-compose-xpto.yml`|

