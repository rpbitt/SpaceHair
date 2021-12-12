-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 08-Jul-2021 às 00:44
-- Versão do servidor: 10.4.19-MariaDB
-- versão do PHP: 7.4.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `spacehair`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `colaborador`
--

CREATE TABLE `colaborador` (
  `Id` int(4) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Login` varchar(50) NOT NULL,
  `Senha` varchar(50) NOT NULL,
  `DataContratacao` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `colaborador`
--

INSERT INTO `colaborador` (`Id`, `Nome`, `Login`, `Senha`, `DataContratacao`) VALUES
(1, 'Ana', '741', '963', '2021-06-29 02:06:38'),
(2, 'Vitor', '258', '654', '2021-06-29 02:09:02'),
(3, 'Bruna', '123', '321', '2021-05-06 00:00:00'),
(4, 'Aline', '522', '411', '2021-04-05 00:00:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `servico`
--

CREATE TABLE `servico` (
  `Id` int(4) NOT NULL,
  `Colaborador` int(4) DEFAULT NULL,
  `Nome` varchar(50) NOT NULL,
  `Setor` varchar(50) NOT NULL,
  `Preco` int(50) NOT NULL,
  `Unidade` varchar(50) NOT NULL,
  `DataServico` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `servico`
--

INSERT INTO `servico` (`Id`, `Colaborador`, `Nome`, `Setor`, `Preco`, `Unidade`, `DataServico`) VALUES
(2, 1, 'Escova', 'Cabelos', 50, 'Centro', '2021-06-18 00:00:00'),
(3, 2, 'Corte', 'Cabelos', 85, 'Jardins', '2021-06-05 00:00:00'),
(4, 3, 'Corte', 'Cabelos masculino', 85, 'Pinheiros', '0001-01-01 00:00:00'),
(5, 4, 'Manicure', 'Unhas', 50, 'Moema', '2021-05-29 00:00:00'),
(6, 4, 'Manicure', 'Unhas', 50, 'Moema', '2021-05-29 00:00:00'),
(7, 3, 'Banho de Lua', 'Noivas', 500, 'Jardins', '2021-07-23 00:00:00'),
(8, 3, 'Massagem Tântrica', 'Noivas', 300, 'Pinheiros', '2021-07-10 00:00:00');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `colaborador`
--
ALTER TABLE `colaborador`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `servico`
--
ALTER TABLE `servico`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Colaborador` (`Colaborador`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `colaborador`
--
ALTER TABLE `colaborador`
  MODIFY `Id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `servico`
--
ALTER TABLE `servico`
  MODIFY `Id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `servico`
--
ALTER TABLE `servico`
  ADD CONSTRAINT `servico_ibfk_1` FOREIGN KEY (`Colaborador`) REFERENCES `colaborador` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
