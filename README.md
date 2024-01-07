# Projeto Brigadeiro


### Objetivo

O projeto tem como objetivo a criação de um programa para ajudar no gerenciamento de uma doceria.

### Funções que planejo que estarão presentes na versão 1.0:

- Cadastro de ingredientes
	- O cadastro deve conter as informações dos ingredientes que são necessárias para a formação de preço
	- Ao atualizar os preços, gerar um histórico gráfico

- Cadastro de receitas
	- As receitas devem ser cadastradas a partir dos ingredientes
	- Opção para alterar a composição da receita

- Pedidos (***Implantação pendente***)
	- Os pedidos devem ser compostos por diversas receitas e suas quantidades, também deve apresentar a opção para impressão do pedido
	- Funcionalidade para consultar pedidos antigos
	- Adicionar um campo para itens não listados

- Configurações
	- O programa deve conter configurações gerais para a criação de novos usuários, e as opções para a formação de preço

### Melhorias

- ~~Adicionar custo fixo de 15%, representando gastos diversos, configurável a partir da página de configurações~~
- Adicionar lucro variável que pode ser ajustado na página de pedido (Provisóriamente disponível na área de configurações)

- v2.0 Foco na otimização do acesso ao banco de dados

## Instalação

### ***Este program funciona apenas em sistemas windows***

1. Faça o download do arquivo .zip da versão mais [recente](https://github.com/Robemac2/Projeto-Doceria/releases/latest).

2. Extraia o arquivo .zip para uma pasta do seu computador.

3. Execute o arquivo ***Projeto Brigadeiro.exe***

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/0d682888-5be7-4f14-9c38-f1f616ed79ff)

4. Durante a primeira execução, será necessário criar um usuário master.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/8e1e99d3-f294-492d-9008-a95864281d26)

5. Após criar o usuário, preencha os dados para calcular o custo.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/2303d455-794f-49eb-b331-515b29bc1e00)

6. Após a configuração inicial, faça o LogIn com o usuário que você acabou de criar.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/ed32f82b-5117-4105-9d54-6162ebb8c168)

7. Ao fazer o LogIn, o menu inicial será aberto.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/74c36f26-2e7c-46f7-8dab-8bdd749878c8)

	- Os módulos do programa são:

		- Ingredientes
  		- Receitas
  		- Pedidos
		- Configurações

8. Na área de ***Ingredientes***, é possível executar as seguintes funções:

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/8aafc144-625a-44e8-8b2d-2e6d922369f1)

	- Cadastar novos ingredientes: Basta preencher os campos com os dados do ingrediente.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/c1adea73-ed4b-49f5-a151-1ccb613de169)

	- Depois clicar no botão **Salvar Novo**.

	- Para atualizar, basta selecionar o ingrediente na lista e alterar o preço e a data de atualização. Depois clique em **Atualizar**.

 	- Para filtrar a lista, digite o nome do ingrediente completo ou parcial no campo de pesquisa e clique em **Pesquisar**.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/f1afcf93-678c-4f7b-be42-19c3aa5ee473)

	- Para voltar para a lista completa, clique em **Limpar**.

	- Ao selecionar um ingrediente que já tenha sido atulizado, você pode clicar em **Histórico de Preço**.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/75ec2318-4706-4fdc-81bd-4a1234c7acf6)

	- Dentro dessa página, você pode filtar os históricos usando as opções abaixo do gráfico.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/1c3b797c-285f-4a2f-97ec-a0e8f642ac8a)

	- A última função desse módulo é excuir um ingrediente, basta selecionar o ingrediente desejado e clicar em **Excluir**, apenas o usuário master pode realizar esta ação.

9. Área de ***Receitas***:

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/3faaf519-5927-4c11-a84c-1867e8b710a9)

	- Nessa área é exibido uma lista com as receitas já cadastradas e possui as seguintes opções:

		- Criar **Nova Receita**.

		![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/2375d623-dc0c-4aeb-a41a-778b6d07e0b1)

		- Para adicionar um ingrediente na receita, basta seleciona-lo na lista suspensa e preencher a quantidade utilizada na recieta e clicar em **Adicionar / Atualizar**.

		![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/87d21471-2832-4d9c-bc97-2750e8119752)

		- Depois de secionar todos od ingredientes, preencha o nome da receita, o tempo de preparo e quanto rende uma receita, depois é só clicar em **Salvar Receita**.

		- Na versão atual, não é possível atualizar a receita, é necessário excluir a receita e criar uma nova.

		- Apenas o usuário **master** pode excluir receitas cadastradas.


11. Área de ***Pedidos***,  ainda não está implementada.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/cdece598-b3f6-45a9-a52e-405f197f0f2e)

12. Área de ***Configurações***:

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/74313ffb-ea1b-4484-ac0a-16e633f8b8ff)

	- Na área de usuários:

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/4d2156dc-4205-473f-99d7-ab5dd88aac19)

	- É possível criar novos usuários, apenas o usuário **master** pode criar novos **administradores**, e excluir usuários.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/09946680-7822-47d3-b07e-d216aabd2197)

	- Na área de configurações de custo, exibe os dados inseridos na primeira execução do programa.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/1b3d6a46-ebe8-4681-9868-4e227cab591a)

	- Esses dados só podem ser alterados por **administradores** ou pelo usuário **master**, para alterar os dados, clique no botão **Atualizar**, para desbloquear os campos para edição.

	![image](https://github.com/Robemac2/Projeto-Doceria/assets/82005650/d45dff78-d8c5-43de-aee8-bcbcfa2cfbdb)

