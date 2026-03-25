-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Már 25. 12:14
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `champs`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orders`
--

CREATE TABLE `orders` (
  `id` int(1) NOT NULL,
  `name` varchar(6) DEFAULT NULL,
  `role` varchar(8) DEFAULT NULL,
  `lane` varchar(3) DEFAULT NULL,
  `difficulty` int(1) DEFAULT NULL,
  `blue_essence` int(5) DEFAULT NULL,
  `damage_type` varchar(5) DEFAULT NULL,
  `images` varchar(6) DEFAULT NULL,
  `description` varchar(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `orders`
--

INSERT INTO `orders` (`id`, `name`, `role`, `lane`, `difficulty`, `blue_essence`, `damage_type`, `images`, `description`) VALUES
(0, 'string', 'assassin', 'top', 1, 99999, 'mixed', 'string', 'string'),
(1, 'Kayn', 'mixed', 'jun', 4, 9999, 'Attac', 'kayn.p', 'Good C');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
