# 📚 WPF - Advanced Programming (C#)

Este repositório contém material e anotações da disciplina **Programação Avançada em WPF com C#**.

---

## 🎥 Guias em Vídeo (YouTube)

| Parte   | Link                                                                     |
| ------- | ------------------------------------------------------------------------ |
| Parte 1 | [▶️ Ver no YouTube](https://www.youtube.com/watch?v=Ckig8H_h538&t=1153s) |
| Parte 2 | [▶️ Ver no YouTube](https://www.youtube.com/watch?v=o_ECnZ8zk_Q)         |

---

## 🧭 Guia de Comandos Git

### 📌 Branch Principal

| Comando | Descrição                                            |
| ------- | ---------------------------------------------------- |
| `main`  | Nome padrão da branch principal. Antes era `master`. |

### 🔍 Verificar o Estado do Repositório

| Comando      | Descrição                                                        |
| ------------ | ---------------------------------------------------------------- |
| `git status` | Mostra os ficheiros novos, modificados ou em espera para commit. |

### ➕ Adicionar Ficheiros à Área de Preparação

| Comando                | Descrição                                |
| ---------------------- | ---------------------------------------- |
| `git add nomeFicheiro` | Adiciona um ficheiro específico.         |
| `git add .`            | Adiciona todos os ficheiros modificados. |

### 💾 Fazer Commit das Alterações

| Comando                    | Descrição                                                              |
| -------------------------- | ---------------------------------------------------------------------- |
| `git commit -m "Mensagem"` | Guarda as alterações no repositório local com uma mensagem descritiva. |

### 🚀 Enviar Alterações para o Repositório Remoto

| Comando                  | Descrição                                         |
| ------------------------ | ------------------------------------------------- |
| `git push origin branch` | Envia as alterações da branch local para a cloud. |

### 📜 Ver Histórico de Commits

| Comando   | Descrição                    |
| --------- | ---------------------------- |
| `git log` | Exibe os commits realizados. |

### 🔀 Mesclar Branches

| Comando            | Descrição                                                                                                                        |
| ------------------ | -------------------------------------------------------------------------------------------------------------------------------- |
| `git merge branch` | Mescla as alterações de outra branch para a branch atual. <br>Após o merge, usa `git push` para enviar as mudanças para a cloud. |

### ✏️ Alterar o Nome da Branch Principal

| Comando              | Descrição                               |
| -------------------- | --------------------------------------- |
| `git branch -M main` | Renomeia a branch `master` para `main`. |

### ⬇️ Atualizar o Projeto com as Alterações da Cloud

| Comando    | Descrição                                 |
| ---------- | ----------------------------------------- |
| `git pull` | Puxa as alterações do repositório remoto. |

### ⬇️ Descartar todas as alterações não commitadas

| Comando            | Descrição                                     |
| ------------------ | --------------------------------------------- |
| `git reset --hard` | Descartar todas as alterações não commitadas. |

---

## 📥 Clonar um Repositório GitHub para o PC

1. Aceder ao GitHub, abrir o projeto e copiar o link do repositório.
2. Abrir o terminal (Git Bash ou outro).
3. Usar o comando:
   ```bash
   git clone "link"
   ```
   > Isto copia o projeto para a pasta onde o comando foi executado.

---

## 🚀 Criar um Repositório Local e Enviá-lo para o GitHub

1. Criar uma pasta e abrir o terminal dentro dela.
2. Inicializar o repositório:
   ```bash
   git init
   ```
3. Criar um repositório no GitHub e copiar o link HTTPS.
4. Associar o repositório remoto:
   ```bash
   git remote add origin https://github.com/username/repo.git
   ```
5. Enviar os ficheiros para o GitHub:
   ```bash
   git add .
   git commit -m "Primeiro commit"
   git push origin main
   ```

---

## 🌿 Branches - Ramificações do Projeto

1. Criar uma nova branch:
   ```bash
   git branch "nome_da_branch"
   ```
2. Ver as branches existentes:
   ```bash
   git branch
   ```
3. Mudar para uma branch específica:
   ```bash
   git checkout "nome_da_branch"
   ```
4. Criar e mudar para a nova branch diretamente:
   ```bash
   git checkout -b "nome_da_branch"
   ```
5. Enviar a nova branch para o GitHub:
   ```bash
   git push --set-upstream origin "nome_da_branch"
   ```
6. Depois disso, usa normalmente:
   ```bash
   git status
   git add .
   git commit -m "mensagem"
   git push
   ```
