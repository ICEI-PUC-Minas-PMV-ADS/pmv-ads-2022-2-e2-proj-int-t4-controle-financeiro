## Plano de Testes de Software

| Casos de Teste | CT-01 - Criar usuário e senha |
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-14 - O sistema terá tela de Login e senha |
|`Objetivo do teste` | Testar o acesso a tela de login, criar um usário e senha e testar a redefinição de senha |
|`Passos` | 
||1 - Abrir o navegador  |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Clicar no botão "Login" |
||4 - Clicar no botão Ainda não possuo cadastro |
||5 - Preencher os campos obrigatórios (Nome, Ultimo nome, E-mail, Username, Data de Nascimento, Telefone, Crie uma senha, Confirme a senha) |
||6 - Clicar no botão Criar > Clicar no botão "Esqueceu sua senha?" |
||7 - Preencher campo "E-mail" |
||8 - Clicar no botão "Enviar" |
|`Critério de Êxito` | O usuário criou um login e senha e conseguiu redefinir a senha. |
|`Avaliação` | O usuário "admin" e a senha "123456" foram criados, ***redefinição de senha?*** |


| Casos de Teste | CT-02 - Acessar tela inicial |
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-13 - O sistema terá tela inicial // RF-08 -  O sistema terá uma área com conteúdos (curadoria) voltados para educação financeira |
|`Objetivo do teste` | Testar o acesso a página home/Lançamentos |
|`Dados de entrada` | Usuário: admin Senha: 123456 |
|`Passos` |
||1 - Abrir o navegador |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Clicar nos conteúdos |
|`Critério de Êxito` | A página home/Lançamentos foi executada. |
|`Avaliação` | A página Home/Lançamentos foi acessada e visualizada.  |


| Casos de Teste | CT-03 - Criar categorias e agrupar categorias |
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-01 -  O sistema permite agrupar valores por seções (categorias) // RF-02 - O sistema permite agrupar categorias |
|`Objetivo do teste` | Testar a criação e o agrupamento de categorias |
|`Passos` | 
||1 - Abrir o navegador |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Informar o Username e Senha |
||4 - Clicar no botão "Login" |
||5 - Clicar no botão " + " |
||6 - Clicar no botão "Criar categoria" |
||7 - Clicar na categoria desejada |
||8 - Clicar no botão para selecionar categoria |
||9 - Clicar no botão de "agrupar" |
|`Critério de Êxito` | As categorias foram criadas e  agrupadas. |
|`Avaliação` | As categorias "Casas, Uber Driver, Contas mensais, Lanches, Qualidade de vida" foram criadas. ***Agrupamento??***  |


| Casos de Teste | CT-04 - Fazer e programar lançamentos, visualizar lançamentos por período (entradas, saídas, receitas e despesas por mês, trimestre ou ano) e visualizar os informes de contas a vencer |
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-03 - O sistema permite o lançamento de débitos // RF-04 - O sistema permite o lançamento de créditos // RF-07 - O sistema permite datar/programar lançamentos (exemplo: pagamentos ou recebimentos futuros) // RF-09 - O sistema permite a visualização de entradas, saídas, ativos e passivos por mês, trimestre e ano em uma única tela // RF-11 - O sistema informa as contas a vencer |
|`Passos` | 
||1 - Abrir o navegador |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Informar o Username e Senha > Clicar no botão "Login" |
||4 - Clicar no botão " + " |
||5 - Clicar na categoria desejada |
||6 - Clicar no botão "+" |
||7 - Clicar no botão "programar lançamento" |
||8 - Clicar no botão "filtrar período" |
||9 - Clicar no período desejado (mês, trimestre, ano) |
||10 - Clicar no pop-up "contas a vencer" |
|`Critério de Êxito` | Lançamentos feitos com sucesso, lançamentos programados com sucesso, Filtros por período realizado e contas a vencer visualizadas. |
|`Avaliação` | Lançamentos de receita e despesa cadastrados. ***Lançamentos programados? Filtrar período?*** |


| Casos de Teste | CT-05 - Fazer a conciliação de gastos de cartão de crédito e filtrar lançamentos conciliados ou não conciliados |
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-05 - O sistema permite a conciliação dos gastos do cartão de crédito // RF-06 - O sistema permite filtrar os lançamentos conciliados e os não conciliados |
|`Objetivo do teste` | Testar o agrupamento de categorias |
|`Passos` | 
||1 - Abrir o navegador |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Informar o Username e Senha |
||4 - Clicar no botão "Login" |
||5 - Selecionar os lançamentos de cartão de crédito |
||6 - Clicar no botão "conciliar" |
||7 - Clicar no botão "filtrar" |
||8 - Clicar na opção "Lançamentos conciliados"  |
|`Critério de Êxito` | Lançamentos de cartão de crédito conciliados com sucesso e filtrados com sucesso. |
|`Avaliação` | ***Conciliação??*** |


| Casos de Teste | CT-06 - Definir meta e simular possíveis cenários de atingimento da meta |
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-10 - O sistema permite a definição e simulação (com manipulação) do atingimento da meta estabelecida |
|`Objetivo do teste` | Lançar meta e testar a simulação de atingimento  |
|`Passos` | 
||1 - Abrir o navegador |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Informar o Username e Senha |
||4 - Clicar no botão "Login" |
||5 - Clicar no botão "Meta" |
||6 - Lançar uma meta |
||7 - Clicar no botão "Simular" |
||8 - Fazer simulação de lançamentos  |
|`Critério de Êxito` | Meta cadastrada e seu atingimento simulado. |
|`Avaliação` | ***Simulação e meta?*** |


| Casos de Teste | CT-07 - Emitir relatórios |
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-12 - O sistema emitirá relatórios comparativos entre períodos determinados pelo usuário (relatório de evolução do atingimento da meta) |
|`Objetivo do teste` | Emitir relatórios comparativos e relatórios de evolução da meta   |
|`Passos` | 
||1 - Abrir o navegador |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Informar o Username e Senha |
||4 - Clicar no botão "Login" |
||5 - Clicar no botão "relatório" |
||6 - Definir relatório a ser emitido  |
|`Critério de Êxito` | Relatórios emitidos com sucesso.  |
|`Avaliação` | ***Relatórios?*** |
