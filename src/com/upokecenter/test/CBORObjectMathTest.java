package com.upokecenter.test;
/*
 * Created by SharpDevelop.
 * User: PeterRoot
 * Date: 11/7/2013
 * Time: 9:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

import org.junit.Assert;
import org.junit.Test;
import com.upokecenter.util.*;

import java.math.*;


	
	public class CBORObjectMathTest
	{
		@Test
		public void CBORAdditionTest() {
			Assert.assertEquals("1089595639448406721.00006187844301460638314800466464049577552941627800464630126953125",CBORObject.Addition(
				CBORObject.FromObject(6.187844301460638E-5d),
				CBORObject.FromObject(1089595639448406721L)).AsDecimalFraction().toString());
			Assert.assertEquals("99.7502799107018773838717606849968433380126953125",CBORObject.Addition(
				CBORObject.FromObject(93.96945477260984d),
				CBORObject.FromObject(5.780825f)).AsDecimalFraction().toString());
			Assert.assertEquals("4606920435721410785.39855587430286",CBORObject.Addition(
				CBORObject.FromObject(4606920435721410781L),
				CBORObject.FromObject(DecimalFraction.FromString("439855587430286E-14"))).AsDecimalFraction().toString());
			Assert.assertEquals("2073300000000000.382769405841827392578125",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("20733E+11")),
				CBORObject.FromObject(0.3827694f)).AsDecimalFraction().toString());
			Assert.assertEquals("29.9117383696138858795166015625",CBORObject.Addition(
				CBORObject.FromObject(29.866377f),
				CBORObject.FromObject(0.045361493f)).AsDecimalFraction().toString());
			Assert.assertEquals("8178971242448397364682749104983471600952.147532757547350075",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("8178971242448397364682749104983471595392")),
				CBORObject.FromObject(DecimalFraction.FromString("5560.147532757547350075E0"))).AsDecimalFraction().toString());
			Assert.assertEquals("-453.000000644357521854",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-453")),
				CBORObject.FromObject(DecimalFraction.FromString("-644357521854E-18"))).AsDecimalFraction().toString());
			Assert.assertEquals("7389999999999999994.919809818267822265625",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("739E+16")),
				CBORObject.FromObject(-5.08019f)).AsDecimalFraction().toString());
			Assert.assertEquals("-8.8565318361805548371811302093150125980377197265625",CBORObject.Addition(
				CBORObject.FromObject(-8.85653158994297d),
				CBORObject.FromObject(DecimalFraction.FromString("-2462375.853192887508374E-13"))).AsDecimalFraction().toString());
			Assert.assertEquals("3520774562396536772.0480528660118579864501953125",CBORObject.Addition(
				CBORObject.FromObject(3520774562396536772L),
				CBORObject.FromObject(0.048052866f)).AsDecimalFraction().toString());
			Assert.assertEquals("-0.1993306465446949005126953125",CBORObject.Addition(
				CBORObject.FromObject(-0.008629937f),
				CBORObject.FromObject(-0.19070071f)).AsDecimalFraction().toString());
			Assert.assertEquals("-1815028339341501192.10944442426839977298",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("046391051542425.89055557573160022702")),
				CBORObject.FromObject(-1815074730393043618L)).AsDecimalFraction().toString());
			Assert.assertEquals("-519960066703964460108515896670316288.9999999999997440069579494794312995321310723426883938259879247567596394219435751438140869140625",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("-519960066703964460108515896670316289")),
				CBORObject.FromObject(2.5599304205052057E-13d)).AsDecimalFraction().toString());
			Assert.assertEquals("-5774272840211.96140985556334178892",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-28658.81672066060911293099")),
				CBORObject.FromObject(DecimalFraction.FromString("-5774272811553.14468919495422885793"))).AsDecimalFraction().toString());
			Assert.assertEquals("2677708415311134816.99980529900131910394658028840009222903972840867936611175537109375",CBORObject.Addition(
				CBORObject.FromObject(2677708415311134817L),
				CBORObject.FromObject(-1.9470099868089605E-4d)).AsDecimalFraction().toString());
			Assert.assertEquals("196.0000000000004361158497704044100351267718988865573575240686121645694584003649652004241943359375",CBORObject.Addition(
				CBORObject.FromObject(4.361158497704044E-13d),
				CBORObject.FromObject(new BigInteger("196"))).AsDecimalFraction().toString());
			Assert.assertEquals("-664618218304341090",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("52075881")),
				CBORObject.FromObject(-664618218356416971L)).AsDecimalFraction().toString());
			Assert.assertEquals("-0.109522778439673969426426669571128513780422508716583251953125",CBORObject.Addition(
				CBORObject.FromObject(0.006665725362148693d),
				CBORObject.FromObject(-0.116188504f)).AsDecimalFraction().toString());
			Assert.assertEquals("319.022416012128452045037054409936001786451953421419602818787097930908203125",CBORObject.Addition(
				CBORObject.FromObject(319.0224151483916d),
				CBORObject.FromObject(8.637368645090117E-7d)).AsDecimalFraction().toString());
			Assert.assertEquals("505307335938983026287.0000000000000254036367714822863522527075608310506813110329904503714715247042477130889892578125",CBORObject.Addition(
				CBORObject.FromObject(2.5403636771482286E-14d),
				CBORObject.FromObject(new BigInteger("505307335938983026287"))).AsDecimalFraction().toString());
			Assert.assertEquals("-617387129107737043.999999999999999053766145904815677282101789974982820780825191857299483189081001910381019115447998046875",CBORObject.Addition(
				CBORObject.FromObject(-617387129107737044L),
				CBORObject.FromObject(9.462338540951843E-16d)).AsDecimalFraction().toString());
			Assert.assertEquals("-7175811072841485965.99999999999998708352369376714029624399130184160311811945344440122340756715857423841953277587890625",CBORObject.Addition(
				CBORObject.FromObject(-7175811072841485966L),
				CBORObject.FromObject(1.291647630623286E-14d)).AsDecimalFraction().toString());
			Assert.assertEquals("6904209373046255396.337371826171875",CBORObject.Addition(
				CBORObject.FromObject(-231.66263f),
				CBORObject.FromObject(6904209373046255628L)).AsDecimalFraction().toString());
			Assert.assertEquals("-28953893666576455.757697875911372125",CBORObject.Addition(
				CBORObject.FromObject(-48.002857f),
				CBORObject.FromObject(DecimalFraction.FromString("-28953893666576407.7548406676594190"))).AsDecimalFraction().toString());
			Assert.assertEquals("-520884419424.61322356999573171517127968610583728323284023633936434816149585458333604037761688232421875",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-520884419424.61322357")),
				CBORObject.FromObject(4.268284828720314E-12d)).AsDecimalFraction().toString());
			Assert.assertEquals("274.7731781005859375",CBORObject.Addition(
				CBORObject.FromObject(200.77318f),
				CBORObject.FromObject(new BigInteger("74"))).AsDecimalFraction().toString());
			Assert.assertEquals("7427116322946124575.937",CBORObject.Addition(
				CBORObject.FromObject(7752701834987853219L),
				CBORObject.FromObject(DecimalFraction.FromString("-325585512041728643.063"))).AsDecimalFraction().toString());
			Assert.assertEquals("-45482331089169.8144082200000242",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-242E-16")),
				CBORObject.FromObject(DecimalFraction.FromString("-45482331089169.81440822"))).AsDecimalFraction().toString());
			Assert.assertEquals("-7481917355839215314.7463704101736112761500407941639423370361328125",CBORObject.Addition(
				CBORObject.FromObject(-7481917355839215389L),
				CBORObject.FromObject(74.25362958982639d)).AsDecimalFraction().toString());
			Assert.assertEquals("74789814406496421741896877.91579650395361955617090643499977886676788330078125",CBORObject.Addition(
				CBORObject.FromObject(-1.0842034960463804d),
				CBORObject.FromObject(new BigInteger("74789814406496421741896879"))).AsDecimalFraction().toString());
			Assert.assertEquals("-6477456953547722229.02291305650466",CBORObject.Addition(
				CBORObject.FromObject(-6477456910580984122L),
				CBORObject.FromObject(DecimalFraction.FromString("-42966738107.02291305650466E0"))).AsDecimalFraction().toString());
			Assert.assertEquals("8929332621123891869.000000000000007606115152000987410208939999319702473333363636209814018229735665954649448394775390625",CBORObject.Addition(
				CBORObject.FromObject(7.606115152000987E-15d),
				CBORObject.FromObject(8929332621123891869L)).AsDecimalFraction().toString());
			Assert.assertEquals("-584395324193248590440770658864787296959.24425329267978668212890625",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("-584395324193248590440770658864787296959")),
				CBORObject.FromObject(-0.2442533f)).AsDecimalFraction().toString());
			Assert.assertEquals("-0.81541771843453924280802389694771639856718525862788737867958843708038330078125",CBORObject.Addition(
				CBORObject.FromObject(-0.81541777f),
				CBORObject.FromObject(4.8136505679066976E-8d)).AsDecimalFraction().toString());
			Assert.assertEquals("-131449.135633005",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-131449.135633")),
				CBORObject.FromObject(DecimalFraction.FromString("-5E-9"))).AsDecimalFraction().toString());
			Assert.assertEquals("30.330950698807495058417771360836923122406005859375",CBORObject.Addition(
				CBORObject.FromObject(-0.1734072f),
				CBORObject.FromObject(30.50435789580609d)).AsDecimalFraction().toString());
			Assert.assertEquals("-2185571397002111610",CBORObject.Addition(
				CBORObject.FromObject(-6925578532851223727L),
				CBORObject.FromObject(4740007135849112117L)).AsDecimalFraction().toString());
			Assert.assertEquals("-2355210269134529296695685232067204272817.0000000000113264001277221350281676941416423806154034625848225914523936808109283447265625",CBORObject.Addition(
				CBORObject.FromObject(-1.1326400127722135E-11d),
				CBORObject.FromObject(new BigInteger("-2355210269134529296695685232067204272817"))).AsDecimalFraction().toString());
			Assert.assertEquals("3992884460.013753409010889826098884107587323466503903546254150569438934326171875",CBORObject.Addition(
				CBORObject.FromObject(2.350375920596099E-6d),
				CBORObject.FromObject(DecimalFraction.FromString("3992884460.01375105863496923"))).AsDecimalFraction().toString());
			Assert.assertEquals("3396324703085949596.829345703125",CBORObject.Addition(
				CBORObject.FromObject(-392.17065f),
				CBORObject.FromObject(3396324703085949989L)).AsDecimalFraction().toString());
			Assert.assertEquals("27.405853268514803471569181365751269240592889742114124373983941040933132171630859375",CBORObject.Addition(
				CBORObject.FromObject(-2.9695715284308186E-9d),
				CBORObject.FromObject(27.405853f)).AsDecimalFraction().toString());
			Assert.assertEquals("66481777451203681265.7292242620849609375",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("664817774512036812.6180684E+2")),
				CBORObject.FromObject(3.9223843f)).AsDecimalFraction().toString());
			Assert.assertEquals("-1345359418235447854.4046027660369873046875",CBORObject.Addition(
				CBORObject.FromObject(-2.4046028f),
				CBORObject.FromObject(-1345359418235447852L)).AsDecimalFraction().toString());
			Assert.assertEquals("-451166010862059305103980796929",CBORObject.Addition(
				CBORObject.FromObject(5934072623496291035L),
				CBORObject.FromObject(new BigInteger("-451166010867993377727477087964"))).AsDecimalFraction().toString());
			Assert.assertEquals("-9132396782676477677",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("18490535853713671")),
				CBORObject.FromObject(-9150887318530191348L)).AsDecimalFraction().toString());
			Assert.assertEquals("-12985503111787812921",CBORObject.Addition(
				CBORObject.FromObject(-4169866500538325196L),
				CBORObject.FromObject(-8815636611249487725L)).AsDecimalFraction().toString());
			Assert.assertEquals("-671908935408255004.0600409097969532012939453125",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-671908935408255004")),
				CBORObject.FromObject(-0.06004091f)).AsDecimalFraction().toString());
			Assert.assertEquals("48415.340236229740624451789443583038519136607646942138671875",CBORObject.Addition(
				CBORObject.FromObject(0.34023622974062445d),
				CBORObject.FromObject(new BigInteger("48415"))).AsDecimalFraction().toString());
			Assert.assertEquals("6062532686759789525",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-2481833818")),
				CBORObject.FromObject(6062532689241623343L)).AsDecimalFraction().toString());
			Assert.assertEquals("-2299754205679346361.0134203245183425294573265063036160427145659923553466796875",CBORObject.Addition(
				CBORObject.FromObject(-0.01342032451834253d),
				CBORObject.FromObject(-2299754205679346361L)).AsDecimalFraction().toString());
			Assert.assertEquals("-5967105489410287096",CBORObject.Addition(
				CBORObject.FromObject(-5967105489484864936L),
				CBORObject.FromObject(new BigInteger("074577840"))).AsDecimalFraction().toString());
			Assert.assertEquals("-721984209962316794",CBORObject.Addition(
				CBORObject.FromObject(-721984209575477115L),
				CBORObject.FromObject(new BigInteger("-386839679"))).AsDecimalFraction().toString());
			Assert.assertEquals("5003286091572763681.99999999999965449148032827406788",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-3455.0851967172593212E-16")),
				CBORObject.FromObject(5003286091572763682L)).AsDecimalFraction().toString());
			Assert.assertEquals("-949957184966461115.54095458984375",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("-949957184966461302")),
				CBORObject.FromObject(186.45905f)).AsDecimalFraction().toString());
			Assert.assertEquals("-2581392322354672752.71290332356456618",CBORObject.Addition(
				CBORObject.FromObject(-2581392322354672743L),
				CBORObject.FromObject(DecimalFraction.FromString("-971290332356456618E-17"))).AsDecimalFraction().toString());
			Assert.assertEquals("-54.3132591498356278401",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-54.31403321")),
				CBORObject.FromObject(DecimalFraction.FromString("7740601643721599E-19"))).AsDecimalFraction().toString());
			Assert.assertEquals("-6484545743689361726.768890380859375",CBORObject.Addition(
				CBORObject.FromObject(-6484545743689361932L),
				CBORObject.FromObject(205.23111f)).AsDecimalFraction().toString());
			Assert.assertEquals("42.83542127907276153564453125",CBORObject.Addition(
				CBORObject.FromObject(0.109106734f),
				CBORObject.FromObject(42.726315f)).AsDecimalFraction().toString());
			Assert.assertEquals("990.7975674143545783466617576777935028076171875",CBORObject.Addition(
				CBORObject.FromObject(989.7069187947126d),
				CBORObject.FromObject(DecimalFraction.FromString("1.090648619642"))).AsDecimalFraction().toString());
			Assert.assertEquals("-52893642944917412137.3037872314453125",CBORObject.Addition(
				CBORObject.FromObject(166.69621f),
				CBORObject.FromObject(DecimalFraction.FromString("-52893642944917412304"))).AsDecimalFraction().toString());
			Assert.assertEquals("3547362333613881151",CBORObject.Addition(
				CBORObject.FromObject(3547362333656868955L),
				CBORObject.FromObject(new BigInteger("-42987804"))).AsDecimalFraction().toString());
			Assert.assertEquals("1.719438790524952785806451814669227888174828089429269084575935266911983489990234375",CBORObject.Addition(
				CBORObject.FromObject(-7.500716282560482E-10d),
				CBORObject.FromObject(1.7194388f)).AsDecimalFraction().toString());
			Assert.assertEquals("163.68128857474880375197376596709274418991265608959833070985834257982105555129237473011016845703125",CBORObject.Addition(
				CBORObject.FromObject(163.6812885747488d),
				CBORObject.FromObject(-1.5792089001558206E-15d)).AsDecimalFraction().toString());
			Assert.assertEquals("-3876462703.9999999997993961696451869913648328300998326979842634187889416352845728397369384765625",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-3876462704")),
				CBORObject.FromObject(2.00603830354813E-10d)).AsDecimalFraction().toString());
			Assert.assertEquals("605268840750377993642875589292.0000000000673741908417059793446812410023355997823468754859277396462857723236083984375",CBORObject.Addition(
				CBORObject.FromObject(6.737419084170598E-11d),
				CBORObject.FromObject(new BigInteger("605268840750377993642875589292"))).AsDecimalFraction().toString());
			Assert.assertEquals("-6908482993895962072",CBORObject.Addition(
				CBORObject.FromObject(-6800296482755871402L),
				CBORObject.FromObject(-108186511140090670L)).AsDecimalFraction().toString());
			Assert.assertEquals("-33.3064439065180542339265230111777782440185546875",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-038318E-10")),
				CBORObject.FromObject(-33.306440074718054d)).AsDecimalFraction().toString());
			Assert.assertEquals("-343519648247563226036829471420805538.3926694671",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-47027392.3926694671")),
				CBORObject.FromObject(new BigInteger("-343519648247563226036829471373778146"))).AsDecimalFraction().toString());
			Assert.assertEquals("0.01014821045101625957843883570070679826411602689656792628848658299745011390768922865390777587890625",CBORObject.Addition(
				CBORObject.FromObject(9.37023517711695E-15d),
				CBORObject.FromObject(0.01014821f)).AsDecimalFraction().toString());
			Assert.assertEquals("-0.0012349257939086495452376806696292987908236682415008544921875",CBORObject.Addition(
				CBORObject.FromObject(-0.0012211708448616495d),
				CBORObject.FromObject(DecimalFraction.FromString("-13754949047E-15"))).AsDecimalFraction().toString());
			Assert.assertEquals("16495732629526387",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-4384692")),
				CBORObject.FromObject(new BigInteger("16495732633911079"))).AsDecimalFraction().toString());
			Assert.assertEquals("83610650978021660746969",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-13184424043991881")),
				CBORObject.FromObject(DecimalFraction.FromString("83610664162445704.73885E+6"))).AsDecimalFraction().toString());
			Assert.assertEquals("2299978209967190436",CBORObject.Addition(
				CBORObject.FromObject(2299978209960559074L),
				CBORObject.FromObject(DecimalFraction.FromString("6631362"))).AsDecimalFraction().toString());
			Assert.assertEquals("5156900312324973219",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("-044210278")),
				CBORObject.FromObject(5156900312369183497L)).AsDecimalFraction().toString());
			Assert.assertEquals("-0.020452566710115233257483158268996703554876148700714111328125",CBORObject.Addition(
				CBORObject.FromObject(-0.023175428f),
				CBORObject.FromObject(0.0027228609800331203d)).AsDecimalFraction().toString());
			Assert.assertEquals("39442872161250971595130963678825012548.00000000000019723399005158128943079495891271894127279827590992766772615141235291957855224609375",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("39442872161250971595130963678825012548")),
				CBORObject.FromObject(1.972339900515813E-13d)).AsDecimalFraction().toString());
			Assert.assertEquals("0.9657888412475585937500",CBORObject.Addition(
				CBORObject.FromObject(0.6693976f),
				CBORObject.FromObject(0.29639125f)).AsDecimalFraction().toString());
			Assert.assertEquals("-72380371946635640615180",CBORObject.Addition(
				CBORObject.FromObject(-7062715607420615180L),
				CBORObject.FromObject(DecimalFraction.FromString("-7237330923102822E+7"))).AsDecimalFraction().toString());
			Assert.assertEquals("-94.99999998985461031906424068743137662830522405243982575484551489353179931640625",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-95")),
				CBORObject.FromObject(1.014538968093576E-8d)).AsDecimalFraction().toString());
			Assert.assertEquals("2942054755239162649205",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-2157565")),
				CBORObject.FromObject(new BigInteger("2942054755239164806770"))).AsDecimalFraction().toString());
			Assert.assertEquals("-9127049424127225624.3934326171875",CBORObject.Addition(
				CBORObject.FromObject(-9127049424127225872L),
				CBORObject.FromObject(247.60657f)).AsDecimalFraction().toString());
			Assert.assertEquals("4.3664895975791235827045966289006173610687255859375",CBORObject.Addition(
				CBORObject.FromObject(0.029691467f),
				CBORObject.FromObject(4.336798130517485d)).AsDecimalFraction().toString());
			Assert.assertEquals("245471752608903",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("8")),
				CBORObject.FromObject(DecimalFraction.FromString("245471752608895"))).AsDecimalFraction().toString());
			Assert.assertEquals("9588937679668095241365312434335",CBORObject.Addition(
				CBORObject.FromObject(1431159519751909270L),
				CBORObject.FromObject(new BigInteger("9588937679666664081845560525065"))).AsDecimalFraction().toString());
			Assert.assertEquals("35.47073268890380859375",CBORObject.Addition(
				CBORObject.FromObject(6.177203f),
				CBORObject.FromObject(29.29353f)).AsDecimalFraction().toString());
			Assert.assertEquals("21676518924170358002724.9934866162",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("-6.8065133838")),
				CBORObject.FromObject(DecimalFraction.FromString("216765.18924170358002731800E+17"))).AsDecimalFraction().toString());
			Assert.assertEquals("-0.0000145210778548097872581329424441880238116908685697126202285289764404296875",CBORObject.Addition(
				CBORObject.FromObject(-1.146507717614387E-7d),
				CBORObject.FromObject(-1.4406427083048349E-5d)).AsDecimalFraction().toString());
			Assert.assertEquals("-6067619165207136619",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("-7879135")),
				CBORObject.FromObject(-6067619165199257484L)).AsDecimalFraction().toString());
			Assert.assertEquals("305333204.9",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("72504")),
				CBORObject.FromObject(DecimalFraction.FromString("3052607009E-1"))).AsDecimalFraction().toString());
			Assert.assertEquals("-43867089609984380.849133567119906729203648865222930908203125",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("-043867089609985679")),
				CBORObject.FromObject(1298.15086643288d)).AsDecimalFraction().toString());
			Assert.assertEquals("-3834646720497382654.99",CBORObject.Addition(
				CBORObject.FromObject(DecimalFraction.FromString("98218707201E-2")),
				CBORObject.FromObject(-3834646721479569727L)).AsDecimalFraction().toString());
			Assert.assertEquals("31.97142636775970458984375",CBORObject.Addition(
				CBORObject.FromObject(32.57107f),
				CBORObject.FromObject(-0.59964526f)).AsDecimalFraction().toString());
			Assert.assertEquals("-699969717822311411.8548126220703125",CBORObject.Addition(
				CBORObject.FromObject(-157.85481f),
				CBORObject.FromObject(-699969717822311254L)).AsDecimalFraction().toString());
			Assert.assertEquals("30236256464397847083096477697",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("30236256464424345990870548261")),
				CBORObject.FromObject(new BigInteger("-26498907774070564"))).AsDecimalFraction().toString());
			Assert.assertEquals("8354770905378496469447814154339536259983",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("8354770905378496469443438347004241101530")),
				CBORObject.FromObject(4375807335295158453L)).AsDecimalFraction().toString());
			Assert.assertEquals("-5881222127378372.881434210850",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("0424329459910556")),
				CBORObject.FromObject(DecimalFraction.FromString("-6305551587288928.881434210850"))).AsDecimalFraction().toString());
			Assert.assertEquals("2887639108262666868.09448297321796417236328125",CBORObject.Addition(
				CBORObject.FromObject(2887639108262666868L),
				CBORObject.FromObject(0.09448297f)).AsDecimalFraction().toString());
			Assert.assertEquals("435112100000000000000.02269179932773113250732421875",CBORObject.Addition(
				CBORObject.FromObject(0.0226918f),
				CBORObject.FromObject(DecimalFraction.FromString("4351121E+14"))).AsDecimalFraction().toString());
			Assert.assertEquals("-250265219105.815186338185234375",CBORObject.Addition(
				CBORObject.FromObject(-2.086544f),
				CBORObject.FromObject(DecimalFraction.FromString("-0250265219103.72864230132"))).AsDecimalFraction().toString());
			Assert.assertEquals("-33085332812210998933439569.317413330078125",CBORObject.Addition(
				CBORObject.FromObject(new BigInteger("-33085332812210998933439383")),
				CBORObject.FromObject(-186.31741f)).AsDecimalFraction().toString());
			try { CBORObject.Addition(CBORObject.FromObject(Double.NaN),CBORObject.FromObject(3.5023837f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.NaN),CBORObject.FromObject(3.812574964908644E-6d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.NaN),CBORObject.FromObject(23.474629887387266d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.NaN),CBORObject.FromObject(-166.82784f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.NaN),CBORObject.FromObject(5.993239296979466E-10d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.POSITIVE_INFINITY),CBORObject.FromObject(new BigInteger("-043703874024659752541"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.POSITIVE_INFINITY),CBORObject.FromObject(0.23853742f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.POSITIVE_INFINITY),CBORObject.FromObject(-164.26022f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.POSITIVE_INFINITY),CBORObject.FromObject(new BigInteger("-3454197004716216037476684"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.POSITIVE_INFINITY),CBORObject.FromObject(3.6649623f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.NEGATIVE_INFINITY),CBORObject.FromObject(4.920178f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.NEGATIVE_INFINITY),CBORObject.FromObject(DecimalFraction.FromString("-2775394107351658213.29237024329"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.NEGATIVE_INFINITY),CBORObject.FromObject(DecimalFraction.FromString("5354394.3316793E-16"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.NEGATIVE_INFINITY),CBORObject.FromObject(new BigInteger("35"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Double.NEGATIVE_INFINITY),CBORObject.FromObject(new BigInteger("-724734631380034337"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.NaN),CBORObject.FromObject(-1.6585551286059796E-6d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.NaN),CBORObject.FromObject(DecimalFraction.FromString("4470484868626699E-12"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.NaN),CBORObject.FromObject(51.165462f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.NaN),CBORObject.FromObject(-8526307050682317212L)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.NaN),CBORObject.FromObject(-5178277071860853800L)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.POSITIVE_INFINITY),CBORObject.FromObject(-4.501634965667704E-11d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.POSITIVE_INFINITY),CBORObject.FromObject(DecimalFraction.FromString("-087829913964415877"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.POSITIVE_INFINITY),CBORObject.FromObject(DecimalFraction.FromString("914.9E-19"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.POSITIVE_INFINITY),CBORObject.FromObject(-0.10745481f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.POSITIVE_INFINITY),CBORObject.FromObject(3624504802515453345L)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.NEGATIVE_INFINITY),CBORObject.FromObject(8200506367764127039L)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.NEGATIVE_INFINITY),CBORObject.FromObject(new BigInteger("-3594433687266085256412604739746153"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.NEGATIVE_INFINITY),CBORObject.FromObject(new BigInteger("-75230249292446971480280879652518"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.NEGATIVE_INFINITY),CBORObject.FromObject(1.9599492372504113E-13d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Addition(CBORObject.FromObject(Float.NEGATIVE_INFINITY),CBORObject.FromObject(322.3261f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
		}
		
		@Test
		public void CBORSubtractTest() {
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("346356007189210337696095210412"));
				CBORObject b=CBORObject.FromObject(6066514617521137153L);
				Assert.assertEquals("346356007183143823078574073259",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("84812561899554690973554871212596"));
				CBORObject b=CBORObject.FromObject(62.707386f);
				Assert.assertEquals("84812561899554690973554871212533.292613983154296875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(12.6878729827517d);
				CBORObject b=CBORObject.FromObject(new BigInteger("904494447134823735435963838"));
				Assert.assertEquals("-904494447134823735435963825.3121270172483008309427532367408275604248046875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-8851947516818411559L);
				CBORObject b=CBORObject.FromObject(0.24109761f);
				Assert.assertEquals("-8851947516818411559.24109761416912078857421875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("6112"));
				CBORObject b=CBORObject.FromObject(new BigInteger("-02555515724580714396344640862713"));
				Assert.assertEquals("2555515724580714396344640868825",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-089108.5980319587332970E-5"));
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("-7418265198052351.70196"));
				Assert.assertEquals("7418265198052350.810874019680412667030",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("177"));
				CBORObject b=CBORObject.FromObject(5363123330033215072L);
				Assert.assertEquals("-5363123330033214895",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("116003900156"));
				CBORObject b=CBORObject.FromObject(-1766220146835292942L);
				Assert.assertEquals("1766220262839193098",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(0.050294317f);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("-5141608421350562853"));
				Assert.assertEquals("5141608421350562853.050294317305088043212890625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(70.48056f);
				CBORObject b=CBORObject.FromObject(27.830172f);
				Assert.assertEquals("42.6503887176513671875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("6421583965841160548432660774"));
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("-35720713.25140849364684112333E0"));
				Assert.assertEquals("6421583965841160548468381487.25140849364684112333",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("1268897246813768.356705944452013"));
				CBORObject b=CBORObject.FromObject(new BigInteger("9063685280691"));
				Assert.assertEquals("1259833561533077.356705944452013",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("21777470211"));
				CBORObject b=CBORObject.FromObject(8602542517353909603L);
				Assert.assertEquals("-8602542495576439392",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("-24678161897287"));
				CBORObject b=CBORObject.FromObject(-1.8961014f);
				Assert.assertEquals("-24678161897285.10389864444732666015625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-0.8539986f);
				CBORObject b=CBORObject.FromObject(new BigInteger("-87203"));
				Assert.assertEquals("87202.146001398563385009765625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(24.693441627116798d);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("767526676781.1331037E-5"));
				Assert.assertEquals("-7675242.0743697039202024235089193098247051239013671875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-35.30134022539256d);
				CBORObject b=CBORObject.FromObject(new BigInteger("-5812259802630750159"));
				Assert.assertEquals("5812259802630750123.69865977460744232985234702937304973602294921875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("0065014463571599289421135114033921933"));
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("4187366"));
				Assert.assertEquals("65014463571599289421135114029734567",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(0.12892367f);
				CBORObject b=CBORObject.FromObject(-7246298462423693395L);
				Assert.assertEquals("7246298462423693395.12892366945743560791015625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-94"));
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("704606082.67827750491205565"));
				Assert.assertEquals("-704606176.67827750491205565",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("-1725369539938057436926650371711554"));
				CBORObject b=CBORObject.FromObject(new BigInteger("593971731"));
				Assert.assertEquals("-1725369539938057436926650965683285",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(64.667465f);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("98448994861345341"));
				Assert.assertEquals("-98448994861345276.3325347900390625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("-830554765810011917"));
				CBORObject b=CBORObject.FromObject(new BigInteger("84124116623685514529253120240585557"));
				Assert.assertEquals("-84124116623685515359807886050597474",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-1578971607839072424L);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("40027536"));
				Assert.assertEquals("-1578971607879099960",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-7466E+8"));
				CBORObject b=CBORObject.FromObject(-4675086604394870559L);
				Assert.assertEquals("4675085857794870559",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(3.5925012421663193E-14d);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("4361537998981300516.19060E0"));
				Assert.assertEquals("-4361537998981300516.1905999999999640749875783368067539729155978001598305336498906381592632897081784904003143310546875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(7887546843621803069L);
				CBORObject b=CBORObject.FromObject(2757361815058305617L);
				Assert.assertEquals("5130185028563497452",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-7426267158300916121L);
				CBORObject b=CBORObject.FromObject(new BigInteger("-08149"));
				Assert.assertEquals("-7426267158300907972",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-24.148534633278974d);
				CBORObject b=CBORObject.FromObject(-19.581343f);
				Assert.assertEquals("-4.567191936135419183528938447125256061553955078125",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(234070582574353153L);
				CBORObject b=CBORObject.FromObject(3703525906849000058L);
				Assert.assertEquals("-3469455324274646905",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(1.4741322521622959E-9d);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("808148124317512"));
				Assert.assertEquals("-808148124317511.9999999985258677478377041259586734364456402091025921663458575494587421417236328125",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-8891063857392216127L);
				CBORObject b=CBORObject.FromObject(11.363351f);
				Assert.assertEquals("-8891063857392216138.36335086822509765625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("945280335.0492217949426E+7"));
				CBORObject b=CBORObject.FromObject(new BigInteger("46419759641040973822153"));
				Assert.assertEquals("-46419750188237623329935.050574",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-9E+5"));
				CBORObject b=CBORObject.FromObject(new BigInteger("-948464401260730066392399291208062745218"));
				Assert.assertEquals("948464401260730066392399291208061845218",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(1687400540524960108L);
				CBORObject b=CBORObject.FromObject(9006105132058753898L);
				Assert.assertEquals("-7318704591533793790",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("7203105488637"));
				CBORObject b=CBORObject.FromObject(new BigInteger("-707174126682050733618747359543"));
				Assert.assertEquals("707174126682050740821852848180",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("4182638311653725098276780006908721906"));
				CBORObject b=CBORObject.FromObject(6516955250379052302L);
				Assert.assertEquals("4182638311653725091759824756529669604",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-4837810682711540947L);
				CBORObject b=CBORObject.FromObject(new BigInteger("1352426033190046182380854104920611367"));
				Assert.assertEquals("-1352426033190046187218664787632152314",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("-9176035024138904707703421252791815"));
				CBORObject b=CBORObject.FromObject(new BigInteger("-340360067445785977924850115"));
				Assert.assertEquals("-9176034683778837261917443327941700",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-3559740940911358818L);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("-224495.6214592715253"));
				Assert.assertEquals("-3559740940911134322.3785407284747",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-3072016931551999845L);
				CBORObject b=CBORObject.FromObject(-5978771699599996983L);
				Assert.assertEquals("2906754768047997138",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-1.1230959029827813E-15d);
				CBORObject b=CBORObject.FromObject(-0.009448553f);
				Assert.assertEquals("0.00944855343550331339701693909370818438426369323279531745561621303153287954046390950679779052734375",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("21475"));
				CBORObject b=CBORObject.FromObject(0.17010021f);
				Assert.assertEquals("21474.82989978790283203125",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("-46479853"));
				CBORObject b=CBORObject.FromObject(-1.5589319373737706E-6d);
				Assert.assertEquals("-46479852.999998441068062626229418044334663895345016726423637010157108306884765625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("-6154419980858052181144074744956"));
				CBORObject b=CBORObject.FromObject(-4.405259099122617E-10d);
				Assert.assertEquals("-6154419980858052181144074744955.9999999995594740900877383167594178380271734141171435794603894464671611785888671875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-0.028461827f);
				CBORObject b=CBORObject.FromObject(new BigInteger("-14"));
				Assert.assertEquals("13.97153817303478717803955078125",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(0.032547350158160446d);
				CBORObject b=CBORObject.FromObject(-1793587243808968416L);
				Assert.assertEquals("1793587243808968416.03254735015816044574332721595055772922933101654052734375",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(4400387861681855036L);
				CBORObject b=CBORObject.FromObject(new BigInteger("5716539614078652"));
				Assert.assertEquals("4394671322067776384",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(4.1450223168680926E-7d);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("204368293288E-19"));
				Assert.assertEquals("3.9406540235800925940623679427921022266900763497687876224517822265625E-7",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(0.33502686f);
				CBORObject b=CBORObject.FromObject(-7960929196703574626L);
				Assert.assertEquals("7960929196703574626.33502686023712158203125",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(0.04748803f);
				CBORObject b=CBORObject.FromObject(new BigInteger("5299001030608385631246631135642897968"));
				Assert.assertEquals("-5299001030608385631246631135642897967.9525119699537754058837890625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(2.710699056337099E-6d);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("165159382437537987E+8"));
				Assert.assertEquals("-16515938243753798699999999.9999972893009436629010997020332307538836857929709367454051971435546875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-0.2700341f);
				CBORObject b=CBORObject.FromObject(-5.2997461066280877E-11d);
				Assert.assertEquals("-0.270034104532650121941531623376742861603893339043913623953585556591860949993133544921875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(1.828788542235912E-8d);
				CBORObject b=CBORObject.FromObject(30.886937321923906d);
				Assert.assertEquals("-30.88693730363602041909957068741306011362690586707913098507560789585113525390625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(1286881464988230957L);
				CBORObject b=CBORObject.FromObject(new BigInteger("4489021825990710533141652732533066275"));
				Assert.assertEquals("-4489021825990710531854771267544835318",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("513183489570708"));
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("-689079E-5"));
				Assert.assertEquals("513183489570714.89079",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(5196430339365233860L);
				CBORObject b=CBORObject.FromObject(new BigInteger("-707904038800149736465454850832436848858"));
				Assert.assertEquals("707904038800149736470651281171802082718",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-3.584564327094063E-5d);
				CBORObject b=CBORObject.FromObject(-0.84281087f);
				Assert.assertEquals("0.842775023573648004681616204003535841593475197441875934600830078125",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("05128269048443668887E+5"));
				CBORObject b=CBORObject.FromObject(-42.29741748521973d);
				Assert.assertEquals("512826904844366888700042.29741748521973221386360819451510906219482421875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-1174823795085951245L);
				CBORObject b=CBORObject.FromObject(-4930621708856897950L);
				Assert.assertEquals("3755797913770946705",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-975349.43"));
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("59810631114361567E+14"));
				Assert.assertEquals("-5981063111436156700000000975349.43",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("-6289691266985113942"));
				CBORObject b=CBORObject.FromObject(-3415038455543573772L);
				Assert.assertEquals("-2874652811441540170",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-35535509E-11"));
				CBORObject b=CBORObject.FromObject(3815404146896658757L);
				Assert.assertEquals("-3815404146896658757.00035535509",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("53875238184785825769472569363328138"));
				CBORObject b=CBORObject.FromObject(0.031660635f);
				Assert.assertEquals("53875238184785825769472569363328137.9683393649756908416748046875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("-56626028120864918969145275364872623"));
				CBORObject b=CBORObject.FromObject(new BigInteger("1278"));
				Assert.assertEquals("-56626028120864918969145275364873901",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-1.6535442048385653E-6d);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("-08075273E+14"));
				Assert.assertEquals("807527299999999999999.9999983464557951614346570259721225237825592557783238589763641357421875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(13.345074f);
				CBORObject b=CBORObject.FromObject(-209.63f);
				Assert.assertEquals("222.975078582763671875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-307590.865139925958077E+6"));
				CBORObject b=CBORObject.FromObject(-1007.5293177913348d);
				Assert.assertEquals("-307590864132.3966402856651527570211328566074371337890625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-1.1535023f);
				CBORObject b=CBORObject.FromObject(-3231.97171820982d);
				Assert.assertEquals("3230.8182158647350661340169608592987060546875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(4.486967107594844E-11d);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("115.577678"));
				Assert.assertEquals("-115.577677999955130328924051559064475374862118197370752792352277538157068192958831787109375",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("246768527102897"));
				CBORObject b=CBORObject.FromObject(new BigInteger("60351378"));
				Assert.assertEquals("246768466751519",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-2.7152982684510718E-11d);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("-230820109609889.510708384372E+11"));
				Assert.assertEquals("23082010960988951070838437.19999999997284701731548928248441347053484455457972313041636880370788276195526123046875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-98.766396f);
				CBORObject b=CBORObject.FromObject(-3.246561057194117E-5d);
				Assert.assertEquals("-98.766363103237084308826977674389269168386817909777164459228515625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(0.0082877595f);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("8738070260863467"));
				Assert.assertEquals("-8738070260863466.99171224050223827362060546875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("2116899332579229981380455566654774"));
				CBORObject b=CBORObject.FromObject(-8131490868909175794L);
				Assert.assertEquals("2116899332579238112871324475830568",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-6031553598326517235L);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("7722527005258594.58245424700908187"));
				Assert.assertEquals("-6039276125331775829.58245424700908187",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-3884601511006138881L);
				CBORObject b=CBORObject.FromObject(-0.48894623f);
				Assert.assertEquals("-3884601511006138880.5110537707805633544921875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(5.542882081879096E-13d);
				CBORObject b=CBORObject.FromObject(-9.957308456966182E-5d);
				Assert.assertEquals("0.000099573085123950032157938077618879975216077202605606533136750613266485743224620819091796875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(2225286216387634322L);
				CBORObject b=CBORObject.FromObject(-0.38981488f);
				Assert.assertEquals("2225286216387634322.3898148834705352783203125",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-0.1314829f);
				CBORObject b=CBORObject.FromObject(new BigInteger("3767251807982482291226"));
				Assert.assertEquals("-3767251807982482291226.131482899188995361328125",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(2094526990703050134L);
				CBORObject b=CBORObject.FromObject(new BigInteger("-268737658"));
				Assert.assertEquals("2094526990971787792",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-45689836528464.05"));
				CBORObject b=CBORObject.FromObject(3.438367817744033E-12d);
				Assert.assertEquals("-45689836528464.0500000000034383678177440330346790778569708707241951717303862778862821869552135467529296875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-4672104073755041115L);
				CBORObject b=CBORObject.FromObject(-326907265532196721L);
				Assert.assertEquals("-4345196808222844394",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("-66"));
				CBORObject b=CBORObject.FromObject(-8.643573666898676E-16d);
				Assert.assertEquals("-65.99999999999999913564263331013235388276148038570974828026321178098267949962973943911492824554443359375",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-1.003540046404883E-12d);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("08454440435"));
				Assert.assertEquals("-8454440435.00000000000100354004640488303624913661807860389423192881697133316265535540878772735595703125",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-136.64556347868253d);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("578647485877"));
				Assert.assertEquals("-578647486013.645563478682532831953722052276134490966796875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(new BigInteger("-593498483552893385656602605890152677"));
				CBORObject b=CBORObject.FromObject(347651556843215946L);
				Assert.assertEquals("-593498483552893386004254162733368623",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("5595313E+8"));
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("-82941447507188861501.8839617286773540"));
				Assert.assertEquals("82942007038488861501.8839617286773540",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("3958980491230284488.4701121E+5"));
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("945745218574825"));
				Assert.assertEquals("395898048177283230272186.21",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("6421366491164E+5"));
				CBORObject b=CBORObject.FromObject(new BigInteger("-1"));
				Assert.assertEquals("642136649116400001",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(0.4124196447588869d);
				CBORObject b=CBORObject.FromObject(0.027489457f);
				Assert.assertEquals("0.38493018747944318658227302876184694468975067138671875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-0874365842.754430332"));
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("0522611140756858421"));
				Assert.assertEquals("-522611141631224263.754430332",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-059978"));
				CBORObject b=CBORObject.FromObject(116.37721f);
				Assert.assertEquals("-60094.3772125244140625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-6022273210237766169L);
				CBORObject b=CBORObject.FromObject(-0.20898747f);
				Assert.assertEquals("-6022273210237766168.7910125255584716796875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("28038804917443.80696"));
				CBORObject b=CBORObject.FromObject(0.091602504f);
				Assert.assertEquals("28038804917443.715357495746612548828125",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(-0.020705052f);
				CBORObject b=CBORObject.FromObject(-8164305834977742521L);
				Assert.assertEquals("8164305834977742520.979294948279857635498046875",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(26.160181f);
				CBORObject b=CBORObject.FromObject(DecimalFraction.FromString("-92859642645009.65399224E+8"));
				Assert.assertEquals("9285964264500965399250.1601810455322265625",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-58725562493615.630046131436867E+16"));
				CBORObject b=CBORObject.FromObject(new BigInteger("494165"));
				Assert.assertEquals("-587255624936156300461314862835",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(DecimalFraction.FromString("-5886408069291538.455140188581087E+13"));
				CBORObject b=CBORObject.FromObject(0.061350547f);
				Assert.assertEquals("-58864080692915384551401885810.931350546777248382568359375",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			{
				CBORObject a=CBORObject.FromObject(6206910003785181554L);
				CBORObject b=CBORObject.FromObject(new BigInteger("1800035314513106996497"));
				Assert.assertEquals("-1793828404509321814943",CBORObject.Subtract(a,b).AsDecimalFraction().toString());
				TestCommon.AssertRoundTrip(a);
				TestCommon.AssertRoundTrip(b);
			}
			try { CBORObject.Subtract(CBORObject.FromObject(Double.NaN),CBORObject.FromObject(99.74439f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.NaN),CBORObject.FromObject(0.04503661680757691d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.NaN),CBORObject.FromObject(DecimalFraction.FromString("961.056025725133"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.NaN),CBORObject.FromObject(-2.66673f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.NaN),CBORObject.FromObject(-3249200021658530613L)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.POSITIVE_INFINITY),CBORObject.FromObject(-3082676751896642153L)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.POSITIVE_INFINITY),CBORObject.FromObject(0.37447542485458996d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.POSITIVE_INFINITY),CBORObject.FromObject(DecimalFraction.FromString("6695270"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.POSITIVE_INFINITY),CBORObject.FromObject(8.645616f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.POSITIVE_INFINITY),CBORObject.FromObject(10.918599534632621d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.NEGATIVE_INFINITY),CBORObject.FromObject(1.1195766122143437E-7d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.NEGATIVE_INFINITY),CBORObject.FromObject(-27.678854f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.NEGATIVE_INFINITY),CBORObject.FromObject(DecimalFraction.FromString("51444344646435.890"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.NEGATIVE_INFINITY),CBORObject.FromObject(DecimalFraction.FromString("-795755897.41124405443"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Double.NEGATIVE_INFINITY),CBORObject.FromObject(DecimalFraction.FromString("282349190160173.8945458982215192141"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.NaN),CBORObject.FromObject(-4742894673080640195L)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.NaN),CBORObject.FromObject(-8.057984695058738E-10d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.NaN),CBORObject.FromObject(-6832707275063219586L)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.NaN),CBORObject.FromObject(new BigInteger("3037587108614072"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.NaN),CBORObject.FromObject(DecimalFraction.FromString("-21687"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.POSITIVE_INFINITY),CBORObject.FromObject(21.02954f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.POSITIVE_INFINITY),CBORObject.FromObject(-280.74258f)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.POSITIVE_INFINITY),CBORObject.FromObject(3.295564645540288E-15d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.POSITIVE_INFINITY),CBORObject.FromObject(-1.8643148756498468E-14d)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.POSITIVE_INFINITY),CBORObject.FromObject(DecimalFraction.FromString("56E-9"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.NEGATIVE_INFINITY),CBORObject.FromObject(new BigInteger("06842884252556766213171069781"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.NEGATIVE_INFINITY),CBORObject.FromObject(-6381263349646471084L)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.NEGATIVE_INFINITY),CBORObject.FromObject(9127378784365184230L)).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.NEGATIVE_INFINITY),CBORObject.FromObject(new BigInteger("300921783316"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
			try { CBORObject.Subtract(CBORObject.FromObject(Float.NEGATIVE_INFINITY),CBORObject.FromObject(new BigInteger("-5806763724610384900094490266237212718"))).AsDecimalFraction(); } catch(ArithmeticException ex){ } catch(Throwable ex){ Assert.fail(ex.toString()); }
		}
	}
	
	