# BM
Basketball Data Management System in Kimilab of Sendai NCT


●概要

Basketball Data Management System(BM)のメインアプリケーションです
このプログラム単体では動きません　別途BMLibrary( https://github.com/SatouNishiki/BMLibrary )のダウンロードが必要です

●機能
(★ = β版機能)

・入力機能

・GraphScore
　-　得点の推移

・BoxScore
　-　電子スコアシート

・PlayerData
　-　選手成績詳細

・Tacktick2D
　-　各選手位置別シュート確率推論

・ActionPointGraph
　-　選手別傾向分析
　-　傾向点推移グラフ

・StrategySimulation
  -　戦術シュミレーション

・通信機能

・試合データ編集機能

・チームデータ作成機能

・部員名簿作成機能

・傾向点調整機能

●使い方
BMLibraryをビルドしてdllファイルを生成します
その後本プログラムの参照設定に出来たdllファイルを入れてビルドします
