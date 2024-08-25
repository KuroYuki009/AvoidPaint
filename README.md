# AvoidPaint

## 担当箇所

プレイヤーの移動やスキルの動作制御

敵の移動や攻撃の挙動制御

敵のスポーン制御

シーンの遷移とその際のワイプアニメーション

スコアの受け渡し

## スクリプト

### __敵の制御__

>#### __敵の出現__

敵の出現は一定の時間を経過する度にRandom.Rangeでint値を出し、それを元にswitch文のcase分岐で敵を出現させる場所を選出しています。また、この時にお邪魔キャラの出現条件を満たしているかを確認します。
<br>
選ばれた出現位置が机の上だった場合には、敵を生成させる前に警告アニメーションがされます。AnimationのEvent機能でアニメーションの終了を検出次第、敵を出現させる関数を呼び出すようにしています。
<br>
(参照：[敵を出現させる為のスクリプト](https://github.com/KuroYuki009/AvoidPaint/blob/main/Assets/Script/Enemy/EnemySpawnSc.cs))

>#### __難易度レベル__

難易度レベルは内部の数値の一つであり、一定時間立つごとに上昇していきます。レベルが高ければ敵の出現する頻度が上昇していき、一定以上の難易度になるとお邪魔キャラのクマが出現するようになります。
クマはプレイヤーのプレイエリア外から爆弾を投げてくる敵であり、難易度を下げる事で一時的に消滅させる事が出来ます。


### __各スキルの制御__

>#### __スキル「ダッシュ」__

ダッシュは移動しながら使用する事でその方向へ短距離の高速移動が可能です。
<br>
入力されている移動軸に、加える力分の数値を掛けた上でAddforceのImpulseでプレイヤーのRigidbodyに力を加えています。
<br>
(参照：[プレイヤー移動スクリプト_メゾット"ForceDash"](https://github.com/KuroYuki009/AvoidPaint/blob/main/Assets/Script/Player/NewPlayerMove.cs#L107-L118))

>#### __スキル「ガード」__

ガードを使用すると少しの間、一切のダメージを受けなくなります。
<br>
対応したボタン入力時にプレイヤーのステータス内の変数にある「ガード使用の有無」変数を切り替える事でダメージを受けないようにしています。
使用後にはクールタイムが発生し、その間は使う事ができなくなります。
<br>
使用時に画面上に描画されるイメージは、不透明度を徐々に上げていくようにしています。
<br>
(参照：[ガードスキルのスクリプト](https://github.com/KuroYuki009/AvoidPaint/blob/main/Assets/Script/Player/Skills/skill_Guard.cs)、
[プレイヤーステータスのスクリプト](https://github.com/KuroYuki009/AvoidPaint/blob/main/Assets/Script/Player/PlayerStatus.cs))

>#### __スキル「アルティメット」__

アルティメットを使用すると、敵キャラクターとそれらの攻撃を消す球体をプレイヤー自身を始点に広がっていきます。一定の大きさまで広がり切った後、消した数に応じた時間を制限時間に加算します。また、同時に難易度レベルを低下させる効果もあります。
<br>
使用時に描画される球体はUnityにある3dメッシュのスフィアを流用しており、発動と同時に球体のサイズを徐々に大きくさせています。また、これらから衝突を判定を取っています。
<br>
一定のサイズまで大きくなったのを検出したら、メッシュのサイズをリセットし表示も無効化した後、消したオブジェクト数を元に制限時間へ追加の時間を加算しています。
<br>
(参照：[ウルトのスクリプト](https://github.com/KuroYuki009/AvoidPaint/blob/main/Assets/Script/Player/ULTController.cs))

>#### __収集アイテム__

アルティメットを使用するには全４種類の収集アイテムが必要です。各種アイテムはプレイエリアである机の上に、時間経過でランダムな位置に出現します。回収したアイテムは画面左下のUIに点灯して表示されます。
<br>
すべての種類のアイテムを収集した状態で対応したボタンを押す事でウルトが発動します。
<br>
(参照：[アルティメット発動のスクリプト](https://github.com/KuroYuki009/AvoidPaint/blob/main/Assets/Script/Player/Skills/skill_ULT.cs))


### __その他__

>#### __シーン遷移時のワイプアニメーション__

シーンの遷移時に再生されるワイプのアニメーションはCanvas上に表示した画像をUnityのAnimation機能で動かして実装しており実装しています。また、ゲーム内で体力がゼロになった際に再生されるワイプも同じように実装しています。

>#### __シーン間のスコアの受け渡し__

時間切れ、もしくはプレイヤー体力がゼロなる事でゲームが終了します。
ゲームが終了すると、プレイヤーの消したオブジェクト数、生存時間、ゲーム終了時点の体力値を集計したスコアを数値遷移用のstatic変数に入れた後に、リザルトシーンへ遷移を行う方法でスコアの受け渡しを行っています。
<br>
(参照：[リザルト画面のスクリプト](https://github.com/KuroYuki009/AvoidPaint/blob/main/Assets/ResultManager.cs)、
[ゲームマネージャーのスクリプト_メゾット"Result"](https://github.com/KuroYuki009/AvoidPaint/blob/main/Assets/Script/InGameManager.cs#L257-L277))
