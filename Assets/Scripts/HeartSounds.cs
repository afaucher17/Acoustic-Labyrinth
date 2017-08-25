using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSounds : MonoBehaviour
{
    public static HeartProblem ThirdHeart;
    public static HeartProblem FourthHearth;
    public static HeartProblem AorticStenosis;
    public static HeartProblem MitralRegurgitation;
    public static HeartProblem MidsystolicClick;
    public static HeartProblem VentricularSeptalDefect;
    public static HeartProblem AtrialSeptalDefect;
    public static HeartProblem MitralStenosis;
    public static HeartProblem AorticRegurgitation;
	public static Heart NormalHeart;
	public static List<Heart> HeartProblems = new List<Heart>();

	public static Heart GetRandomHeartProblem(Heart exception)
	{
		var filteredList = HeartProblems.FindAll (x => x != exception);
		return filteredList [Random.Range (0, filteredList.Count)];
	}

	public static Heart GetRandomHeartProblem(List<Heart> exception)
	{
		var filteredList = HeartProblems.FindAll (x => (exception.Find (y => y == x)) == null);
		return filteredList [Random.Range (0, filteredList.Count)];
	}

	public static Heart GetRandomHeartProblem()
	{
		return HeartProblems [Random.Range (0, HeartProblems.Count)];
	}

    private void Awake()
    {
        #region ThirdHeart
        // Create new Instance
        ThirdHeart = new HeartProblem();
        ThirdHeart.formattedName = "T h i r d  H e a r t - S 3";
		ThirdHeart.name = "Third Heart";
        ThirdHeart.audioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - third heart");

        // Each QuickFact is a slide with a Next Button
        ThirdHeart.quickFacts01 = "The third heart sound is caused by a sudden deceleration of blood flow.";
        ThirdHeart.quickFacts01 += System.Environment.NewLine;
        ThirdHeart.quickFacts01 += System.Environment.NewLine;
        ThirdHeart.quickFacts01 += "The third heart sound or S3 is a rare extra heart sound that occurs soon after the normal two 'lub-dub' heart sounds.";

        ThirdHeart.quickFacts02 = "In young people and athletes it is a normal phenomenon. In older individuals it indicates the presence of congestive heart failure.";
        ThirdHeart.quickFacts02 += System.Environment.NewLine;
        ThirdHeart.quickFacts02 += System.Environment.NewLine;
        ThirdHeart.quickFacts02 += "In the presence of a third heart sound(S3) the first heart sound is decreased in intensity while the second heart sound is increased in intensity.";

        ThirdHeart.quickFacts03 = "The third heart sound is a low frequency sound best heard with the bell of the stethoscope pressed lightly on the skin of the chest.";

        // Each SlideSound array should contain the sounds for each QuickFacts line
        ThirdHeart.slide01Sounds = new AudioClip[2];
        ThirdHeart.slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 1");
        ThirdHeart.slide01Sounds[1] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 2");

        ThirdHeart.slide02Sounds = new AudioClip[3];
        ThirdHeart.slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 3");
        ThirdHeart.slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 4");
        ThirdHeart.slide02Sounds[2] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 5");

        ThirdHeart.slide03Sounds = new AudioClip[1];
        ThirdHeart.slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 6");

		HeartProblems.Add(ThirdHeart);
        #endregion

        #region FourthHearth
        FourthHearth = new HeartProblem();
        FourthHearth.formattedName = "F o u r t h  H e a r t - S 4";
		FourthHearth.name = "Fourth Heart";
        FourthHearth.audioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - fourth heart");

        FourthHearth.quickFacts01 = "The fourth heart sound is an extra heart sound immediately before the normal two 'lub - dub' heart sounds.";
        FourthHearth.quickFacts01 += System.Environment.NewLine;
        FourthHearth.quickFacts01 += System.Environment.NewLine;
        FourthHearth.quickFacts01 += "It has also been termed an atrial gallop because of its occurrence late in the heart cycle.";

        FourthHearth.quickFacts02 = "It is a type of Gallop rhythm by virtue of having an extra sound.";

        FourthHearth.quickFacts03 = "It does not require treatment.";
        FourthHearth.quickFacts03 += System.Environment.NewLine;
        FourthHearth.quickFacts03 += System.Environment.NewLine;
        FourthHearth.quickFacts03 += "Rather treatment should be focused on treating the underlying primary disease.";

        FourthHearth.slide01Sounds = new AudioClip[2];
        FourthHearth.slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/fourth heart sound -1");
        FourthHearth.slide01Sounds[1] = Resources.Load<AudioClip>("Sounds/other/fourth heart sound -2");

        FourthHearth.slide02Sounds = new AudioClip[1];
        FourthHearth.slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/fourth heart sound -3");

        FourthHearth.slide03Sounds = new AudioClip[1];
        FourthHearth.slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/fourth heart sound -4");

		HeartProblems.Add(FourthHearth);
        #endregion

        #region Aortic Stenosis
        AorticStenosis = new HeartProblem();
        AorticStenosis.formattedName = "A o r t i c  S t e n o s i s";
		AorticStenosis.name = "Aortic Stenosis";
        AorticStenosis.audioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - aortic stenosis");

        AorticStenosis.quickFacts01 = "Aortic Stenosis is a narrowing of the aortic valve opening.";

        AorticStenosis.quickFacts02 = "It is one of the most common and most serious valve disease problems.";
        AorticStenosis.quickFacts02 += System.Environment.NewLine;
        AorticStenosis.quickFacts02 += System.Environment.NewLine;
        AorticStenosis.quickFacts02 += "This condition more commonly develops during aging.";

        AorticStenosis.quickFacts03 = "The most concrete symptom can be when there is a decline in routine physical activities.";

        AorticStenosis.slide01Sounds = new AudioClip[1];
        AorticStenosis.slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic stenosis - 1");

        AorticStenosis.slide02Sounds = new AudioClip[2];
        AorticStenosis.slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic stenosis - 2");
        AorticStenosis.slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/aortic stenosis - 3");

        AorticStenosis.slide03Sounds = new AudioClip[1];
        AorticStenosis.slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic stenosis - 4");

		HeartProblems.Add(AorticStenosis);
        #endregion

        #region MitralRegurgitation
        MitralRegurgitation = new HeartProblem();
        MitralRegurgitation.formattedName = "M i t r a l \nR e g u r g i t a t i o n";
		MitralRegurgitation.name = "Mitral Regurgitation";
        MitralRegurgitation.audioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - mitral regurgitation");

        MitralRegurgitation.quickFacts01 = "* Mitral regurgitation is leakage of blood backward through " +
            "the mitral valve each time the left ventricle contracts.";

        MitralRegurgitation.quickFacts02 = "* A leaking mitral valve allows blood to flow in two directions during the contraction.";
        MitralRegurgitation.quickFacts02 += System.Environment.NewLine;
        MitralRegurgitation.quickFacts02 += System.Environment.NewLine;
        MitralRegurgitation.quickFacts02 += "* Some blood flows from the ventricle through the aortic valve — as it should — and some blood flows back into the atrium.";

        MitralRegurgitation.quickFacts03 = "* Leakage can increase blood volume and pressure in the area.";
        MitralRegurgitation.quickFacts03 += System.Environment.NewLine;
        MitralRegurgitation.quickFacts03 += System.Environment.NewLine;
        MitralRegurgitation.quickFacts03 += "* If regurgitation is severe, increased pressure may result in congestion (or fluid build-up) in the lungs.";

		HeartProblems.Add(MitralRegurgitation);
        #endregion

        #region MidsystolicClick
        MidsystolicClick = new HeartProblem();
        MidsystolicClick.formattedName = "M i d s y s t o l i c  \nC l i c k";
		MidsystolicClick.name = "Midsystolic Click";
        MidsystolicClick.audioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - midsystolic click");

        MidsystolicClick.quickFacts01 = "It is a high-frequency sound that results from the abrupt halting of prolapsing mitral valve leaflets' excursion.";
        MidsystolicClick.quickFacts01 += System.Environment.NewLine;
        MidsystolicClick.quickFacts01 += System.Environment.NewLine;
        MidsystolicClick.quickFacts01 += "The midsystolic click is produced by the sudden prolapse of the leaflet.";

        MidsystolicClick.quickFacts02 = "It is commonly a result of degeneration of the valve.";
        MidsystolicClick.quickFacts02 += System.Environment.NewLine;
        MidsystolicClick.quickFacts02 += System.Environment.NewLine;
        MidsystolicClick.quickFacts02 += "There is an abnormal ratio between the length of the mitral apparatus and the volume of the left ventricular chamber.";

        MidsystolicClick.quickFacts03 = "The mitral valve is ‘‘too long’’ for the size of the ventricular chamber. ";

        MidsystolicClick.slide01Sounds = new AudioClip[2];
        MidsystolicClick.slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/midsistick click - 1");
        MidsystolicClick.slide01Sounds[1] = Resources.Load<AudioClip>("Sounds/other/midsistick click - 2");

        MidsystolicClick.slide02Sounds = new AudioClip[2];
        MidsystolicClick.slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/midsistick click - 3");
        MidsystolicClick.slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/midsistick click - 4");

        MidsystolicClick.slide03Sounds = new AudioClip[1];
        MidsystolicClick.slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/midsistick click - 5");

		HeartProblems.Add(MidsystolicClick);
        #endregion

        #region VentricularSeptalDefect
        VentricularSeptalDefect = new HeartProblem();
        VentricularSeptalDefect.formattedName = "V e n t r i c u l a r\nS e p t a l  D e f e c t";
		VentricularSeptalDefect.name = "Ventricular Septal Defect";
        VentricularSeptalDefect.audioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - ventricular septal defect");

        VentricularSeptalDefect.quickFacts01 = "Ventricular Septal Defect is a hole in the heart.";
        VentricularSeptalDefect.quickFacts01 += System.Environment.NewLine;
        VentricularSeptalDefect.quickFacts01 += System.Environment.NewLine;
        VentricularSeptalDefect.quickFacts01 += "It is a common heart defect that is present at birth.";

        VentricularSeptalDefect.quickFacts02 = "A small ventricular septal defect may cause no problems.";
        VentricularSeptalDefect.quickFacts02 += System.Environment.NewLine;
        VentricularSeptalDefect.quickFacts02 += System.Environment.NewLine;
        VentricularSeptalDefect.quickFacts02 += "Larger VSDs need surgical repair early in life to prevent complications.";

        VentricularSeptalDefect.quickFacts03 = "The hole allows blood to pass from the left to the right side of the heart. ";
        VentricularSeptalDefect.quickFacts03 += System.Environment.NewLine;
        VentricularSeptalDefect.quickFacts03 += System.Environment.NewLine;
        VentricularSeptalDefect.quickFacts03 += "The blood then gets pumped back to the lungs, causing the heart to work harder.";

        VentricularSeptalDefect.slide01Sounds = new AudioClip[2];
        VentricularSeptalDefect.slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect -1");
        VentricularSeptalDefect.slide01Sounds[1] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect - 2");

        VentricularSeptalDefect.slide02Sounds = new AudioClip[2];
        VentricularSeptalDefect.slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect - 3");
        VentricularSeptalDefect.slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect - 4");

        VentricularSeptalDefect.slide03Sounds = new AudioClip[2];
        VentricularSeptalDefect.slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect - 5");
        VentricularSeptalDefect.slide03Sounds[1] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect - 6");

		HeartProblems.Add(VentricularSeptalDefect);
        #endregion

        #region AtrialSeptalDefect
        AtrialSeptalDefect = new HeartProblem();
        AtrialSeptalDefect.formattedName = "A t r i a l  S e p t a l\n D e f e c t";
		AtrialSeptalDefect.name = "Atrial Septal Defect";
        AtrialSeptalDefect.audioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - atrial septal defect");

        AtrialSeptalDefect.quickFacts01 = "An atrial septal defect is a hole in the wall between the two upper chambers of the heart.";

        AtrialSeptalDefect.quickFacts02 = "The condition is present from birth.";
        AtrialSeptalDefect.quickFacts02 += System.Environment.NewLine;
        AtrialSeptalDefect.quickFacts02 += System.Environment.NewLine;
        AtrialSeptalDefect.quickFacts02 += "Small atrial septal defects may close on their own during infancy or early childhood.";

        AtrialSeptalDefect.quickFacts03 = "Large and long-standing atrial septal defects can damage your heart and lungs.";
        AtrialSeptalDefect.quickFacts03 += System.Environment.NewLine;
        AtrialSeptalDefect.quickFacts03 += System.Environment.NewLine;
        AtrialSeptalDefect.quickFacts03 += "Surgery may be necessary to repair atrial septal defects to prevent complications.";

        AtrialSeptalDefect.slide01Sounds = new AudioClip[1];
        AtrialSeptalDefect.slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortial septal defect - 1");

        AtrialSeptalDefect.slide02Sounds = new AudioClip[2];
        AtrialSeptalDefect.slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortial septal defect - 2");
        AtrialSeptalDefect.slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/aortial septal defect - 3");

        AtrialSeptalDefect.slide03Sounds = new AudioClip[2];
        AtrialSeptalDefect.slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortial septal defect - 4");
        AtrialSeptalDefect.slide03Sounds[1] = Resources.Load<AudioClip>("Sounds/other/aortial septal defect - 5");

		HeartProblems.Add(AtrialSeptalDefect);
        #endregion

        #region MitralStenosis
        MitralStenosis = new HeartProblem();
        MitralStenosis.formattedName = "M i t r a l  S t e n o s i s";
		MitralStenosis.name = "Mitral Stenosis";
        MitralStenosis.audioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - mitral stenosis");

        MitralStenosis.quickFacts01 = "Mitral Stenosis is a narrowing of the heart's mitral valve.";

        MitralStenosis.quickFacts02 = "The abnormal valve doesn't open properly, blocking blood flow into the main pumping chamber.";
        MitralStenosis.quickFacts02 += System.Environment.NewLine;
        MitralStenosis.quickFacts02 += System.Environment.NewLine;
        MitralStenosis.quickFacts02 += "It can make you tired and short of breath, among other problems.";

        MitralStenosis.quickFacts03 = "The main cause of the anomaly is an infection called rheumatic fever.";

        MitralStenosis.slide01Sounds = new AudioClip[1];
        MitralStenosis.slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/mitro stenosis -1");

        MitralStenosis.slide02Sounds = new AudioClip[2];
        MitralStenosis.slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/mitro stenosis -2");
        MitralStenosis.slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/mitro stenosis -3");

        MitralStenosis.slide03Sounds = new AudioClip[1];
        MitralStenosis.slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/mitro stenosis -4");

		HeartProblems.Add(MitralStenosis);
        #endregion

        #region AorticRegurgitation
        AorticRegurgitation = new HeartProblem();
        AorticRegurgitation.formattedName = "A o r t i c  \nR e g u r g i t a t i o n";
		AorticRegurgitation.name = "Aortic Regurgitation";
        AorticRegurgitation.audioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - aortic regurgitation");


        AorticRegurgitation.quickFacts01 = "It disrupts the way blood normally flows through your heart and its valves.";
        AorticRegurgitation.quickFacts01 += System.Environment.NewLine;
        AorticRegurgitation.quickFacts01 += System.Environment.NewLine;
        AorticRegurgitation.quickFacts01 += "Any condition that damages the aortic valve can cause regurgitation.";

        AorticRegurgitation.quickFacts02 = "It is also called a 'leaky heart valve', aortic insufficiency or aortic incompetence.";
        AorticRegurgitation.quickFacts02 += System.Environment.NewLine;
        AorticRegurgitation.quickFacts02 += System.Environment.NewLine;
        AorticRegurgitation.quickFacts02 += "The abnormal valve can develop suddenly or over decades. ";

        AorticRegurgitation.quickFacts03 = "Rheumatic fever or infection is among the causes of the anomaly.";
        AorticRegurgitation.quickFacts03 += System.Environment.NewLine;
        AorticRegurgitation.quickFacts03 += System.Environment.NewLine;
        AorticRegurgitation.quickFacts03 += "Once it becomes severe, surgery is usually required to repair or replace the aortic valve.";

        AorticRegurgitation.slide01Sounds = new AudioClip[1];
        AorticRegurgitation.slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 1");
        //AorticRegurgitation.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 2");

        AorticRegurgitation.slide02Sounds = new AudioClip[2];
        AorticRegurgitation.slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 3");
        AorticRegurgitation.slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 4");

        AorticRegurgitation.slide03Sounds = new AudioClip[2];
        AorticRegurgitation.slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 5");
        AorticRegurgitation.slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 6");

		HeartProblems.Add(AorticRegurgitation);

		NormalHeart = new Heart();
		NormalHeart.formattedName = "Normal heart beat";
		NormalHeart.audioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - normal beat");
        #endregion
    }
}

public class Heart {
	public string formattedName;
	public string name;
	public AudioClip audioClip;

	public string quickFacts01;
	public AudioClip[] slide01Sounds;

	public string quickFacts02;
	public AudioClip[] slide02Sounds;

	public string quickFacts03;
	public AudioClip[] slide03Sounds;
}

public class HeartProblem : Heart
{
}