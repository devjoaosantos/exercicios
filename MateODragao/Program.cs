﻿using System;
using MateODragao.Models;

namespace MateODragao {
    class Program {
        static void Main (string[] args) {
            bool jogadorNaoDesistiu = true;
            do {

                Console.Clear ();
                System.Console.WriteLine ("==============================");
                System.Console.WriteLine ("        Mate o Dragão!");
                System.Console.WriteLine ("==============================");

                System.Console.WriteLine (" 1 - Iniciar jogo");
                System.Console.WriteLine (" 0 - Sair do jogo");

                string opcaoJogador = Console.ReadLine ();

                switch (opcaoJogador) {
                    case "1":
                        Console.Clear ();
                        Guerreiro guerreiro = new Guerreiro ();
                        guerreiro.Nome = "Mark";
                        guerreiro.Sobrenome = "Zuckerberg";
                        guerreiro.CidadeNatal = "Suica - Zurique";
                        guerreiro.DataNascimento = DateTime.Parse ("14/05/1000");
                        guerreiro.FerramentaAtaque = "Picareta";
                        guerreiro.FerramentaDefesa = "Escudo";
                        guerreiro.Forca = 2;
                        guerreiro.Inteligencia = 4;
                        guerreiro.Destreza = 2;
                        guerreiro.Vida = 20;

                        Dragao dragao = new Dragao ();
                        dragao.Nome = "Dragonaldo";
                        dragao.Forca = 5;
                        dragao.Destreza = 1;
                        dragao.Inteligencia = 3;
                        dragao.Vida = 300;

                        /* INCIO - PRIMEIRO DIÁLOGO */
                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Seu louco! Vim te derrotar");
                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Humano tolinho, quem pensas que és?");

                        System.Console.WriteLine ();
                        System.Console.WriteLine ("Aperte ENTER para prosseguir!");
                        Console.ReadLine ();
                        /* FIM - PRIMEIRO DIÁLOGO */

                        /* INICIO - SEGUNDO DIÁLOGO */
                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Eu sou {guerreiro.Nome}! Da casa {guerreiro.Sobrenome}, ò criatura morfética");
                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Vim de {guerreiro.CidadeNatal} para te derrotar e mostrar meu valor!");
                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: QUEM? DE ONDE? Bom, que seja... Fritar-te-ei e devorar-te-ei, primata insolente!");
                        System.Console.WriteLine ("BAMBAM: Tá na hora do show!");

                        System.Console.WriteLine ();
                        System.Console.WriteLine ("Aperte ENTER para prosseguir!");
                        Console.ReadLine ();

                        /* FIM - SEGUNDO DIÁLOGO */
                        Console.Clear ();
                        bool jogadorAtacaPrimeiro = guerreiro.Destreza > dragao.Destreza ? true : false;

                        int poderAtaqueGuerreiro = guerreiro.Forca > guerreiro.Inteligencia ? guerreiro.Forca + guerreiro.Destreza : guerreiro.Inteligencia + guerreiro.Destreza;

                        bool jogadorNaoCorreu = true;

                        if (jogadorAtacaPrimeiro) {
                            System.Console.WriteLine ("***Turno do Jogador***");
                            System.Console.WriteLine ("Escolha uma ação");
                            System.Console.WriteLine (" 1 - Atacar");
                            System.Console.WriteLine (" 2 - Fugir");

                            string opcaoBatalhaJogador = Console.ReadLine ();

                            switch (opcaoBatalhaJogador) {
                                case "1":
                                    Random geradorNumeroAleatorio = new Random ();
                                    int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                                    int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                                    int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                                    int dragaoDestrezaTotal = dragao.Destreza + numeroAleatorioDragao;

                                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal) {
                                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: TOMA ESSA, MALDITO!");
                                        dragao.Vida = dragao.Vida - (poderAtaqueGuerreiro + 5);
                                        System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine ($"HP Guerreiro: {guerreiro.Vida}");
                                    } else {
                                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Você é muito fraco!  ");
                                    }

                                    break;
                                case "2":
                                    System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: FUI! Flw Vlw");
                                    System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Muito facil!");
                                    jogadorNaoCorreu = false;
                                    break;
                            }
                        }

                        System.Console.WriteLine ();
                        System.Console.WriteLine ("Aperte ENTER para continuar!");
                        Console.ReadLine ();

                        while (guerreiro.Vida > 0 && dragao.Vida > 0 && jogadorNaoCorreu) {
                            Console.Clear ();
                            System.Console.WriteLine ("***Turno do Dragão***");
                            Random geradorNumeroAleatorio = new Random ();
                            int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                            int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                            int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                            int dragaoDestrezaTotal = dragao.Destreza + numeroAleatorioDragao;

                            if (guerreiroDestrezaTotal > dragaoDestrezaTotal) {
                                System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Fritou o forévis, foi?");
                                guerreiro.Vida = guerreiro.Vida - dragao.Forca;
                                System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                System.Console.WriteLine ($"HP Guerreiro: {guerreiro.Vida}");
                            } else {
                                System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: EEEEEERROU! ");
                            }

                            System.Console.WriteLine();
                            System.Console.WriteLine("Aperte ENTER para prosseguir!");
                            Console.ReadLine();

                            Console.Clear();
                            
                            System.Console.WriteLine ("***Turno do Jogador***");
                            System.Console.WriteLine ("Escolha uma ação");
                            System.Console.WriteLine (" 1 - Atacar");
                            System.Console.WriteLine (" 2 - Fugir");

                            string opcaoBatalhaJogador = Console.ReadLine ();

                            switch (opcaoBatalhaJogador) {
                                case "1":
                                    geradorNumeroAleatorio = new Random ();
                                    numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                                    numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                                    guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                                    dragaoDestrezaTotal = dragao.Destreza + numeroAleatorioDragao;

                                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal) {
                                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: TOMA ESSA, MALDITO!");
                                        dragao.Vida = dragao.Vida - (poderAtaqueGuerreiro + 5);
                                        System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine ($"HP Guerreiro: {guerreiro.Vida}");
                                    } else {
                                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Você é muito fraco!  ");
                                    }

                                    break;
                                case "2":
                                    System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: FUI! Flw Vlw");
                                    System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Muito facil!");
                                    jogadorNaoCorreu = false;
                                    break;
                            }
                            




                        }

                        break;
                    case "0":
                        jogadorNaoDesistiu = false;
                        System.Console.WriteLine ("GAME OVER");
                        break;
                    default:
                        System.Console.WriteLine ("Comando Inválido!");
                        break;
                }
            } while (jogadorNaoDesistiu);

        }
    }
}