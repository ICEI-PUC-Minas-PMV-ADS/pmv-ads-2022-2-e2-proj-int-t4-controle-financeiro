# Plano de Testes de Software

Tipo do Teste:	Funcional 
Subtipo de teste:	 Requisitos 
Objetivo do teste:	Testar a separação de gastos por seção 
Requisitos que motivaram esse teste:	RF-01 - O sistema permite separar gastos por seções (categorias) 
	
Tipo do Teste:	Funcional 
Subtipo de teste:	 Requisitos
Objetivo do teste:	Testar a separação de “valores a pagar” por seção 
Requisitos que motivaram esse teste:	 RF-02 - O sistema permite separar de valores a pagar por seção (categoria) 
	
Tipo do Teste:	 Funcional
Subtipo de teste:	 Requisitos
Objetivo do teste:	Testar o lançamento de débitos 
Requisitos que motivaram esse teste:	 RF-03 - O sistema permite o lançamento de débitos
	
Tipo do Teste:	 Funcional
Subtipo de teste:	 Requisitos 
Objetivo do teste:	Testar o lançamento de créditos 
Requisitos que motivaram esse teste:	 RF-04 – O sistema permite o lançamento de créditos  
	
Tipo do Teste:	 Funcional 
Subtipo de teste:	 Requisitos 
Objetivo do teste:	Testar a conciliação dos gastos de cartão de crédito 
Requisitos que motivaram esse teste:	 RF-05 – O sistema permite a conciliação dos gastos do cartão de crédito 
	
Tipo do Teste:	Funcional  
Subtipo de teste:	 Requisitos 
Objetivo do teste:	Testar o filtro de lançamentos conciliados e não conciliados 
Requisitos que motivaram esse teste:	 RF-06 – O sistema permite filtrar os lançamentos conciliados e os não conciliados 
	
	
Tipo do Teste:	Funcional 
Subtipo de teste:	 Requisitos
Objetivo do teste:	 Testar programação de lançamentos futuros
Requisitos que motivaram esse teste:	 RF-07 – O sistema permite datar/programar lançamentos (Ex: pagamentos/recebimentos futuros)
	
	
Tipo do Teste:	 Funcional
Subtipo de teste:	Requisitos 
Objetivo do teste:	 Testar área/página de conteúdo de educação financeira
Requisitos que motivaram esse teste:	 RF-08 – O sistema terá uma área com conteúdo voltado para educação financeira
	
Tipo do Teste:	 Funcional 
Subtipo de teste:	 Requisitos 
Objetivo do teste:	Testar a visualização de entradas, saídas, ativos e débitos mensais, trimestrais e anuais na mesma tela 
Requisitos que motivaram esse teste:	 RF-09 – O sistema permite a visualização de entradas, saídas, ativos e débitos por mês, trimestre e ano em uma única tela 
	
Tipo do Teste:	 Funcional 
Subtipo de teste:	 Requisitos 
Objetivo do teste:	 Testar a definição e simulação (com manipulação) do atingimento de meta 
Requisitos que motivaram esse teste:	RF-010 - O sistema permite a definição e simulação (com manipulação) do atingimento da meta estabelecida 
	
Tipo do Teste:	Funcional 
Subtipo de teste:	 Requisitos
Objetivo do teste:	 Testar os informes de contas a vencer
Requisitos que motivaram esse teste:	RF-11 – O sistema informa as contas a vencer 
	
Tipo do Teste:	 Funcional 
Subtipo de teste:	Requisitos  
Objetivo do teste:	 Testar a emissão de relatórios comparativos com períodos determinados
Requisitos que motivaram esse teste:	 RF-12 - O sistema emitirá relatórios comparativos entre períodos determinados pelo usuário (relatório de evolução do atingimento da meta)
	
Tipo do Teste:	Funcional  
Subtipo de teste:	 Requisitos
Objetivo do teste:	 Testar a exibição da tela Home/Institucional
Requisitos que motivaram esse teste:	 RF-13 – O sistema terá tela inicial (home/institucional)
 	
Tipo do Teste:	Funcional  
Subtipo de teste:	 Requisitos
Objetivo do teste:	Testar tela de login (fazer acesso, cadastrar usuário, testar redefinição de senha)
Requisitos que motivaram esse teste:	 RF-14 – O sistema terá tela de login e senha


Por exemplo:
 
| **Caso de Teste** 	| **CT-01 – Cadastrar perfil** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-00X - A aplicação deve apresentar, na página principal, a funcionalidade de cadastro de usuários para que esses consigam criar e gerenciar seu perfil. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Clicar em "Criar conta" <br> - Preencher os campos obrigatórios (e-mail, nome, sobrenome, celular, CPF, senha, confirmação de senha) <br> - Aceitar os termos de uso <br> - Clicar em "Registrar" |
|Critério de Êxito | - O cadastro foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login	|
|Requisito Associado | RF-00Y	- A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Clicar no botão "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Clicar em "Login" |
|Critério de Êxito | - O login foi realizado com sucesso. |

 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
