# Plano de Testes de Software

**Casos de Teste**  | **CT-01 - Acessar tela inicial**

`Requisitos Associados` - RF-13 - O sistema terá tela inicial (home/institucional) // RF-08 -  O sistema terá uma área com conteúdo (curadoria) voltados para educação financeira
`Objetivo do teste` - Testar o acesso a página home/institucional e visualizar conteúdos de educação financeira
`Passos` - Abrir o navegador > Informar o endreço do site https://xxxxxxxxxxx.com.br > Clicar nos conteúdos 
`Critério de Êxito` - A página home/institucional foi acessada com sucesso e os conteúdo de educação financeira executados. 

**CT-02 - Criar usuário e senha**

`Requisitos Associados` - RF-14 - O sistema terá tela de Login e senha
`Objetivo do teste` - Testar o acesso a tela de login, criar um usário e senha e testar a redefinição de senha
`Passos` - Abrir o navegador > Informar o endreço do site https://xxxxxxxxxxx.com.br > Clicar no botão "Login" > Clicar no botão Ainda não possuo cadastro > preencher os campos obrigatórios (Nome, Ultimo nome, E-mail, Username, Data de Nascimento, Telefone, Crie uma senha, Confirme a senha) > Clicar no botão Criar > Clicar no botão "Esqueceu sua senha?" > Preencher campo "E-mail" > Clicar no botão "Enviar"
`Critérios de êxito` - O usuário criou um login e senha e conseguiu redefinir a senha.

**CT-03 - Criar categorias e agrupar categorias**

`Requisitos Associados` - RF-01 -  O sistema permite agrupar valores por seções (categorias) // RF-02 - O sistema permite agrupar valores por subseções (subcategoria)
`Objetivo do teste` - Testar o agrupamento de categorias e de subcategorias
`Passos` - Abrir o navegador > Informar o endreço do site https://xxxxxxxxxxx.com.br > Clicar no botão "Login" > Informar o Username e Senha > Clicar no botão " + " > Clicar na categoria desejada > Clicar no botão para selecionar categoria > Clicar no botão de "agrupar"
`Critérios de êxito`- As categorias foram agrupadas.

**CT-04 - Fazer e programar lançamentos, visualizar lançamentos por período (entradas, saídas, ativos e passivos por mês, trimestre ou ano) e visualizar o informes de contas a vencer**

`Requisitos Associados` - RF-03 - O sistema permite o lançamento de débitos // RF-04 - O sistema permite o lançamento de créditos // RF-07 - O sistema permite datar/programar lançamentos (exemplo: pagamentos ou recebimentos futuros) // RF-09 - O sistema permite a visualização de entradas, saídas, ativos e passivos por mês, trimestre e ano em uma única tela // RF-11 - O sistema informa as contas a vencer
`Objetivo do teste` - Testar os lançamentos e a progrmação de lançamentos futuros, a visualização de lançamentos por período e visualizar o informes de contas a vencer 
`Passos` - Abrir o navegador > Informar o endreço do site https://xxxxxxxxxxx.com.br > Clicar no botão "Login" > Informar o Username e Senha > Clicar no botão " + " > Clicar na categoria desejada > Clicar no botão "+" > Clicar no botão "programar lançamento" > Clicar no botão "filtrar período" > Clicar no período desejado(mês, trimestre, ano) > Clicar no pop-up "contas a vencer" 
`Critérios de êxito` - Lançamentos feitos com sucesso, lançamentos programados com sucesso, Filtros por período realizado e contas a vencer visualizadas.

**CT-05 - Fazer a conciliação de gastos de cartão de crédito e filtrar lançamentos conciliados ou não conciliados**

`Requisitos Associados` - RF-05 - O sistema permite a conciliação dos gastos do cartão de crédito // RF-06 - O sistema permite filtrar os lançamentos conciliados e os não conciliados
`Objetivos do teste` - Testar a conciliação de lançamentos do cartão de crédito e filtrar lançamentos conciliados e não conciliados 
`Passos` - Abrir o navegador > Informar o endreço do site https://xxxxxxxxxxx.com.br > Clicar no botão "Login" > Informar o Username e Senha > Selecionar os lançamentos de cartão de crédito > Clicar no botão "conciliar" > Clicar no botão "filtrar" > Clicar na opção "Lançamentos conciliados" 
`Critérios de êxitos` - Lançamentos de cartão de crédito conciliados com sucesso e filtrados com sucesso.

**CT-06 - Definir meta e simular possíveis cenários de atingimento da meta**

`Requisitos Associados` - RF-10 - O sistema permite a definição e simulação (com manipulação) do atingimento da meta estabelecida
`Objetivos do teste` - Lançar meta e testar a simulação de atingimento 
`Passos` - Abrir o navegador > Informar o endreço do site https://xxxxxxxxxxx.com.br > Clicar no botão "Login" > Informar o Username e Senha > Clicar no botão "Meta" > Lançar uma meta > Clicar no botão "Simular" > Fazer falsos lançamentos (simulação) 
`Critérios de êxito` - Meta cadastrada e seu atingimento simulado.

**CT-07 - Emitir relatórios (diversos)**

`Requisitos Associados` - RF-12 - O sistema emitirá relatórios comparativos entre períodos determinados pelo usuário (relatório de evolução do atingimento da meta)
`Objetivos do teste` - Emitir relatórios comparativos e relatórios de evolução da meta 
`Passos` - Abrir o navegador > Informar o endreço do site https://xxxxxxxxxxx.com.br > Clicar no botão "Login" > Informar o Username e Senha > Clicar no botão "relatório" > Definir relatório a ser emitido
`Critérios de êxito` - Relatórios emitidos com sucesso. 



