using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSounds : MonoBehaviour
{
    public static HeartProblem ThirdHeart;
    public static HeartProblem FourthHearth;
    public static HeartProblem AorticStenosis;
    public static HeartProblem MidsystolicClick;
    public static HeartProblem VentricularSeptalDefect;
    public static HeartProblem AtrialSeptalDefect;
    public static HeartProblem MitralStenosis;
    public static HeartProblem AorticRegurgitation;


    private void Start()
    {
        #region ThirdHeart
        ThirdHeart = new HeartProblem();
        ThirdHeart.NameOfCondition = "Third Heart - S3";
        ThirdHeart.AudioFileName = "Third Heart";

        ThirdHeart.QuickFacts  = "* The third heart sound is caused by a sudden deceleration of blood flow.";
        ThirdHeart.QuickFacts += System.Environment.NewLine;
        ThirdHeart.QuickFacts += "* The third heart sound or S3 is a rare extra heart sound that occurs soon after the normal two 'lub-dub' heart sounds.";
        ThirdHeart.QuickFacts += System.Environment.NewLine;
        ThirdHeart.QuickFacts += "* A third heart sound occurs early in diastole. In young people and athletes it is a normal phenomenon. In older individuals it indicates the presence of congestive heart failure.";
        ThirdHeart.QuickFacts += System.Environment.NewLine;
        ThirdHeart.QuickFacts += "* In the presence of a third heart sound(S3) the first heart sound is decreased in intensity while the second heart sound is increased in intensity.";
        ThirdHeart.QuickFacts += System.Environment.NewLine;
        ThirdHeart.QuickFacts += "* The third heart sound is a low frequency sound best heard with the bell of the stethoscope pressed lightly on the skin of the chest.";
        #endregion

        #region FourthHearth
        FourthHearth = new HeartProblem();
        FourthHearth.NameOfCondition = "Fourth Heart - S4";
        FourthHearth.AudioFileName = "Fourth Heart";

        FourthHearth.QuickFacts  = "* The fourth heart sound is an extra heart sound immediately before the normal two 'lub - dub' heart sounds.";
        FourthHearth.QuickFacts += System.Environment.NewLine;
        FourthHearth.QuickFacts += "* It has also been termed an atrial gallop or a presystolic gallop because of its occurrence late in the heart cycle.";
        FourthHearth.QuickFacts += System.Environment.NewLine;
        FourthHearth.QuickFacts += "* It is a type of Gallop rhythm by virtue of having an extra sound";
        FourthHearth.QuickFacts += System.Environment.NewLine;
        FourthHearth.QuickFacts += "* It does not require treatment; rather plans should be laid to stop the progression of whatever causes the underlying ventricular dysfunction. ";
        FourthHearth.QuickFacts += System.Environment.NewLine;
        FourthHearth.QuickFacts += "* The S4 heart sound is a secondary manifestation of a primary disease process and treatment should be focused on treating the underlying, primary disease.";
        #endregion

        #region Aortic Stenosis
        AorticStenosis = new HeartProblem();
        AorticStenosis.NameOfCondition = "Aortic Stenosis";
        AorticStenosis.AudioFileName = "";

        AorticStenosis.QuickFacts = "* Aortic Stenosis is a narrowing of the aortic valve opening.";
        AorticStenosis.QuickFacts += System.Environment.NewLine;
        AorticStenosis.QuickFacts += "* It is one of the most common and most serious valve disease problems. ";
        AorticStenosis.QuickFacts += System.Environment.NewLine;
        AorticStenosis.QuickFacts += "* This condition more commonly develops during aging.";
        AorticStenosis.QuickFacts += System.Environment.NewLine;
        AorticStenosis.QuickFacts += "* The most concrete symptom can be when there is decline in routine physical activities.";
        AorticStenosis.QuickFacts += System.Environment.NewLine;
        #endregion

        #region MidsystolicClick
        MidsystolicClick = new HeartProblem();
        MidsystolicClick.NameOfCondition = "Midsystolic Click";
        MidsystolicClick.AudioFileName = "";

        MidsystolicClick.QuickFacts = "* It is a high-frequency sound that results from the abrupt halting of prolapsing mitral valve leaflets' excursion.";
        MidsystolicClick.QuickFacts += System.Environment.NewLine;
        MidsystolicClick.QuickFacts += "* The mid-systolic click is produced by the sudden prolapse of the leaflet.";
        MidsystolicClick.QuickFacts += System.Environment.NewLine;
        MidsystolicClick.QuickFacts += "* It is commonly result of degeneration of the valve.";
        MidsystolicClick.QuickFacts += System.Environment.NewLine;
        MidsystolicClick.QuickFacts += "* There is an abnormal ratio between the length of the mitral apparatus and the volume of the left ventricular chamber.";
        MidsystolicClick.QuickFacts += System.Environment.NewLine;
        MidsystolicClick.QuickFacts += "*The mitral valve is ‘’too long’’ for the size of the ventricular chamber.";
        MidsystolicClick.QuickFacts += System.Environment.NewLine;
        #endregion

        //#region ventricularseptaldefect
        //ventricularseptaldefect = new heartproblem();
        //ventricularseptaldefect.nameofcondition = "ventricular septal defect";
        //ventricularseptaldefect.audiofilename = "";

        //ventricularseptaldefect.quickfacts = "* it is a high-frequency sound that results from the abrupt halting of prolapsing mitral valve leaflets' excursion.";
        //ventricularseptaldefect.quickfacts += system.environment.newline;
        //ventricularseptaldefect.quickfacts = "* the mid-systolic click is produced by the sudden prolapse of the leaflet.";
        //midsystolicclick.quickfacts += system.environment.newline;
        //midsystolicclick.quickfacts += "* it is commonly result of degeneration of the valve.";
        //midsystolicclick.quickfacts += system.environment.newline;
        //midsystolicclick.quickfacts += "* there is an abnormal ratio between the length of the mitral apparatus and the volume of the left ventricular chamber.";
        //midsystolicclick.quickfacts += system.environment.newline;
        //midsystolicclick.quickfacts += "*the mitral valve is ‘’too long’’ for the size of the ventricular chamber.";
        //midsystolicclick.quickfacts += system.environment.newline;
        //#endregion

        #region AtrialSeptalDefect

        #endregion

        #region MitralStenosis

        #endregion

        #region AorticRegurgitation

        #endregion

    }

}

public class HeartProblem
{
    public string NameOfCondition;
    public string AudioFileName;
    public string QuickFacts;
}
