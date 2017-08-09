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


    private void Awake()
    {
        #region ThirdHeart
        // Create new Instance
        ThirdHeart = new HeartProblem();
        ThirdHeart.NameOfCondition = "T h i r d  H e a r t - S 3";
        ThirdHeart.AudioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - third heart");

        // Each QuickFact is a slide with a Next Button
        ThirdHeart.QuickFacts01 = "The third heart sound is caused by a sudden deceleration of blood flow.";
        ThirdHeart.QuickFacts01 += System.Environment.NewLine;
        ThirdHeart.QuickFacts01 += System.Environment.NewLine;
        ThirdHeart.QuickFacts01 += "The third heart sound or S3 is a rare extra heart sound that occurs soon after the normal two 'lub-dub' heart sounds.";

        ThirdHeart.QuickFacts02 = "In young people and athletes it is a normal phenomenon. In older individuals it indicates the presence of congestive heart failure.";
        ThirdHeart.QuickFacts02 += System.Environment.NewLine;
        ThirdHeart.QuickFacts02 += System.Environment.NewLine;
        ThirdHeart.QuickFacts02 += "In the presence of a third heart sound(S3) the first heart sound is decreased in intensity while the second heart sound is increased in intensity.";

        ThirdHeart.QuickFacts03 = "The third heart sound is a low frequency sound best heard with the bell of the stethoscope pressed lightly on the skin of the chest.";

        // Each SlideSound array should contain the sounds for each QuickFacts line
        ThirdHeart.Slide01Sounds = new AudioClip[2];
        ThirdHeart.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 1");
        ThirdHeart.Slide01Sounds[1] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 2");

        ThirdHeart.Slide02Sounds = new AudioClip[3];
        ThirdHeart.Slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 3");
        ThirdHeart.Slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 4");
        ThirdHeart.Slide02Sounds[2] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 5");

        ThirdHeart.Slide03Sounds = new AudioClip[1];
        ThirdHeart.Slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/third heart sound - 6");
        #endregion

        #region FourthHearth
        FourthHearth = new HeartProblem();
        FourthHearth.NameOfCondition = "F o u r t h  H e a r t - S 4";
        FourthHearth.AudioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - fourth heart");

        FourthHearth.QuickFacts01 = "The fourth heart sound is an extra heart sound immediately before the normal two 'lub - dub' heart sounds.";
        FourthHearth.QuickFacts01 += System.Environment.NewLine;
        FourthHearth.QuickFacts01 += System.Environment.NewLine;
        FourthHearth.QuickFacts01 += "It has also been termed an atrial gallop because of its occurrence late in the heart cycle.";

        FourthHearth.QuickFacts02 = "It is a type of Gallop rhythm by virtue of having an extra sound.";

        FourthHearth.QuickFacts03 = "It does not require treatment.";
        FourthHearth.QuickFacts03 += System.Environment.NewLine;
        FourthHearth.QuickFacts03 += System.Environment.NewLine;
        FourthHearth.QuickFacts03 += "Rather treatment should be focused on treating the underlying primary disease.";

        FourthHearth.Slide01Sounds = new AudioClip[2];
        FourthHearth.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/fourth heart sound -1");
        FourthHearth.Slide01Sounds[1] = Resources.Load<AudioClip>("Sounds/other/fourth heart sound -2");

        FourthHearth.Slide02Sounds = new AudioClip[1];
        FourthHearth.Slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/fourth heart sound -3");

        FourthHearth.Slide03Sounds = new AudioClip[1];
        FourthHearth.Slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/fourth heart sound -4");

        #endregion

        #region Aortic Stenosis
        AorticStenosis = new HeartProblem();
        AorticStenosis.NameOfCondition = "A o r t i c  S t e n o s i s";
        AorticStenosis.AudioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - aortic stenosis");

        AorticStenosis.QuickFacts01 = "Aortic Stenosis is a narrowing of the aortic valve opening.";

        AorticStenosis.QuickFacts02 = "It is one of the most common and most serious valve disease problems.";
        AorticStenosis.QuickFacts02 += System.Environment.NewLine;
        AorticStenosis.QuickFacts02 += System.Environment.NewLine;
        AorticStenosis.QuickFacts02 += "This condition more commonly develops during aging.";

        AorticStenosis.QuickFacts03 = "The most concrete symptom can be when there is a decline in routine physical activities.";

        AorticStenosis.Slide01Sounds = new AudioClip[1];
        AorticStenosis.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic stenosis - 1");

        AorticStenosis.Slide02Sounds = new AudioClip[2];
        AorticStenosis.Slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic stenosis - 2");
        AorticStenosis.Slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/aortic stenosis - 3");

        AorticStenosis.Slide03Sounds = new AudioClip[1];
        AorticStenosis.Slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic stenosis - 4");
        #endregion

        #region MitralRegurgitation
        MitralRegurgitation = new HeartProblem();
        MitralRegurgitation.NameOfCondition = "M i t r a l \nR e g u r g i t a t i o n";
        MitralRegurgitation.AudioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - mitral regurgitation");

        MitralRegurgitation.QuickFacts01 = "* Mitral regurgitation is leakage of blood backward through " +
            "the mitral valve each time the left ventricle contracts.";

        MitralRegurgitation.QuickFacts02 = "* A leaking mitral valve allows blood to flow in two directions during the contraction.";
        MitralRegurgitation.QuickFacts02 += System.Environment.NewLine;
        MitralRegurgitation.QuickFacts02 += System.Environment.NewLine;
        MitralRegurgitation.QuickFacts02 += "* Some blood flows from the ventricle through the aortic valve — as it should — and some blood flows back into the atrium.";

        MitralRegurgitation.QuickFacts03 = "* Leakage can increase blood volume and pressure in the area.";
        MitralRegurgitation.QuickFacts03 += System.Environment.NewLine;
        MitralRegurgitation.QuickFacts03 += System.Environment.NewLine;
        MitralRegurgitation.QuickFacts03 += "* If regurgitation is severe, increased pressure may result in congestion (or fluid build-up) in the lungs.";
        #endregion

        #region MidsystolicClick
        MidsystolicClick = new HeartProblem();
        MidsystolicClick.NameOfCondition = "M i d s y s t o l i c  \nC l i c k";
        MidsystolicClick.AudioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - midsystolic click");

        MidsystolicClick.QuickFacts01 = "It is a high-frequency sound that results from the abrupt halting of prolapsing mitral valve leaflets' excursion.";
        MidsystolicClick.QuickFacts01 += System.Environment.NewLine;
        MidsystolicClick.QuickFacts01 += System.Environment.NewLine;
        MidsystolicClick.QuickFacts01 += "The midsystolic click is produced by the sudden prolapse of the leaflet.";

        MidsystolicClick.QuickFacts02 = "It is commonly a result of degeneration of the valve.";
        MidsystolicClick.QuickFacts02 += System.Environment.NewLine;
        MidsystolicClick.QuickFacts02 += System.Environment.NewLine;
        MidsystolicClick.QuickFacts02 += "There is an abnormal ratio between the length of the mitral apparatus and the volume of the left ventricular chamber.";

        MidsystolicClick.QuickFacts03 = "The mitral valve is ‘‘too long’’ for the size of the ventricular chamber. ";

        MidsystolicClick.Slide01Sounds = new AudioClip[2];
        MidsystolicClick.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/midsistick click - 1");
        MidsystolicClick.Slide01Sounds[1] = Resources.Load<AudioClip>("Sounds/other/midsistick click - 2");

        MidsystolicClick.Slide02Sounds = new AudioClip[2];
        MidsystolicClick.Slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/midsistick click - 3");
        MidsystolicClick.Slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/midsistick click - 4");

        MidsystolicClick.Slide03Sounds = new AudioClip[1];
        MidsystolicClick.Slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/midsistick click - 5");
        #endregion

        #region VentricularSeptalDefect
        VentricularSeptalDefect = new HeartProblem();
        VentricularSeptalDefect.NameOfCondition = "V e n t r i c u l a r\nS e p t a l  D e f e c t";
        VentricularSeptalDefect.AudioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - ventricular septal defect");

        VentricularSeptalDefect.QuickFacts01 = "Ventricular Septal Defect is a hole in the heart.";
        VentricularSeptalDefect.QuickFacts01 += System.Environment.NewLine;
        VentricularSeptalDefect.QuickFacts01 += System.Environment.NewLine;
        VentricularSeptalDefect.QuickFacts01 += "It is a common heart defect that is present at birth.";

        VentricularSeptalDefect.QuickFacts02 = "A small ventricular septal defect may cause no problems.";
        VentricularSeptalDefect.QuickFacts02 += System.Environment.NewLine;
        VentricularSeptalDefect.QuickFacts02 += System.Environment.NewLine;
        VentricularSeptalDefect.QuickFacts02 += "Larger VSDs need surgical repair early in life to prevent complications.";

        VentricularSeptalDefect.QuickFacts03 = "The hole allows blood to pass from the left to the right side of the heart. ";
        VentricularSeptalDefect.QuickFacts03 += System.Environment.NewLine;
        VentricularSeptalDefect.QuickFacts03 += System.Environment.NewLine;
        VentricularSeptalDefect.QuickFacts03 += "The blood then gets pumped back to the lungs, causing the heart to work harder.";

        VentricularSeptalDefect.Slide01Sounds = new AudioClip[2];
        VentricularSeptalDefect.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect -1");
        VentricularSeptalDefect.Slide01Sounds[1] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect - 2");

        VentricularSeptalDefect.Slide02Sounds = new AudioClip[2];
        VentricularSeptalDefect.Slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect - 3");
        VentricularSeptalDefect.Slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect - 4");

        VentricularSeptalDefect.Slide03Sounds = new AudioClip[2];
        VentricularSeptalDefect.Slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect - 5");
        VentricularSeptalDefect.Slide03Sounds[1] = Resources.Load<AudioClip>("Sounds/other/ventricular septal defect - 6");
        #endregion

        #region AtrialSeptalDefect
        AtrialSeptalDefect = new HeartProblem();
        AtrialSeptalDefect.NameOfCondition = "A t r i a l  S e p t a l\n D e f e c t";
        AtrialSeptalDefect.AudioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - atrial septal defect");

        AtrialSeptalDefect.QuickFacts01 = "An atrial septal defect is a hole in the wall between the two upper chambers of the heart.";

        AtrialSeptalDefect.QuickFacts02 = "The condition is present from birth.";
        AtrialSeptalDefect.QuickFacts02 += System.Environment.NewLine;
        AtrialSeptalDefect.QuickFacts02 += System.Environment.NewLine;
        AtrialSeptalDefect.QuickFacts02 += "Small atrial septal defects may close on their own during infancy or early childhood.";

        AtrialSeptalDefect.QuickFacts03 = "Large and long-standing atrial septal defects can damage your heart and lungs.";
        AtrialSeptalDefect.QuickFacts03 += System.Environment.NewLine;
        AtrialSeptalDefect.QuickFacts03 += System.Environment.NewLine;
        AtrialSeptalDefect.QuickFacts03 += "Surgery may be necessary to repair atrial septal defects to prevent complications.";

        AtrialSeptalDefect.Slide01Sounds = new AudioClip[1];
        AtrialSeptalDefect.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortial septal defect - 1");

        AtrialSeptalDefect.Slide02Sounds = new AudioClip[2];
        AtrialSeptalDefect.Slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortial septal defect - 2");
        AtrialSeptalDefect.Slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/aortial septal defect - 3");

        AtrialSeptalDefect.Slide03Sounds = new AudioClip[2];
        AtrialSeptalDefect.Slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortial septal defect - 4");
        AtrialSeptalDefect.Slide03Sounds[1] = Resources.Load<AudioClip>("Sounds/other/aortial septal defect - 5");

        #endregion

        #region MitralStenosis
        MitralStenosis = new HeartProblem();
        MitralStenosis.NameOfCondition = "M i t r a l  S t e n o s i s";
        MitralStenosis.AudioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - mitral stenosis");

        MitralStenosis.QuickFacts01 = "Mitral Stenosis is a narrowing of the heart's mitral valve.";

        MitralStenosis.QuickFacts02 = "The abnormal valve doesn't open properly, blocking blood flow into the main pumping chamber.";
        MitralStenosis.QuickFacts02 += System.Environment.NewLine;
        MitralStenosis.QuickFacts02 += System.Environment.NewLine;
        MitralStenosis.QuickFacts02 += "It can make you tired and short of breath, among other problems.";

        MitralStenosis.QuickFacts03 = "The main cause of the anomaly is an infection called rheumatic fever.";

        MitralStenosis.Slide01Sounds = new AudioClip[1];
        MitralStenosis.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/mitro stenosis -1");

        MitralStenosis.Slide02Sounds = new AudioClip[2];
        MitralStenosis.Slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/mitro stenosis -2");
        MitralStenosis.Slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/mitro stenosis -3");

        MitralStenosis.Slide03Sounds = new AudioClip[1];
        MitralStenosis.Slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/mitro stenosis -4");
        #endregion

        #region AorticRegurgitation
        AorticRegurgitation = new HeartProblem();
        AorticRegurgitation.NameOfCondition = "A o r t i c  \nR e g u r g i t a t i o n";
        AorticRegurgitation.AudioClip = Resources.Load<AudioClip>("Sounds/other/Acoustic labyrinth - atmospheric sounds - aortic regergitation");


        AorticRegurgitation.QuickFacts01 = "It disrupts the way blood normally flows through your heart and its valves.";
        AorticRegurgitation.QuickFacts01 += System.Environment.NewLine;
        AorticRegurgitation.QuickFacts01 += System.Environment.NewLine;
        AorticRegurgitation.QuickFacts01 += "Any condition that damages the aortic valve can cause regurgitation.";

        AorticRegurgitation.QuickFacts02 = "It is also called a 'leaky heart valve', aortic insufficiency or aortic incompetence.";
        AorticRegurgitation.QuickFacts02 += System.Environment.NewLine;
        AorticRegurgitation.QuickFacts02 += System.Environment.NewLine;
        AorticRegurgitation.QuickFacts02 += "The abnormal valve can develop suddenly or over decades. ";

        AorticRegurgitation.QuickFacts03 = "Rheumatic fever or infection is among the causes of the anomaly.";
        AorticRegurgitation.QuickFacts03 += System.Environment.NewLine;
        AorticRegurgitation.QuickFacts03 += System.Environment.NewLine;
        AorticRegurgitation.QuickFacts03 += "Once it becomes severe, surgery is usually required to repair or replace the aortic valve.";

        AorticRegurgitation.Slide01Sounds = new AudioClip[1];
        AorticRegurgitation.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 1");
        //AorticRegurgitation.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 2");

        AorticRegurgitation.Slide02Sounds = new AudioClip[2];
        AorticRegurgitation.Slide02Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 3");
        AorticRegurgitation.Slide02Sounds[1] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 4");

        AorticRegurgitation.Slide03Sounds = new AudioClip[2];
        AorticRegurgitation.Slide03Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 5");
        AorticRegurgitation.Slide01Sounds[0] = Resources.Load<AudioClip>("Sounds/other/aortic regergitation - 6");
        #endregion
    }
}

public class HeartProblem
{
    public string NameOfCondition;
    public AudioClip AudioClip;

    public string QuickFacts01;
    public AudioClip[] Slide01Sounds;

    public string QuickFacts02;
    public AudioClip[] Slide02Sounds;

    public string QuickFacts03;
    public AudioClip[] Slide03Sounds;
}