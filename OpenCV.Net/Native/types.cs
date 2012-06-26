using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    struct _CvMat
    {
        public int type;
        public int step;
        public IntPtr refcount;
        public int hdr_refcount;
        public IntPtr data;
        public int rows;
        public int cols;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _IplImage
    {
        public int nSize;
        public int ID;
        public int nChannels;
        public int alphaChannel;
        public int depth;
        public byte colorModel0;
        public byte colorModel1;
        public byte colorModel2;
        public byte colorModel3;
        public byte channelSeq0;
        public byte channelSeq1;
        public byte channelSeq2;
        public byte channelSeq3;
        public int dataOrder;
        public int origin;
        public int align;
        public int width;
        public int height;
        public IntPtr roi;
        public IntPtr maskROI;
        public IntPtr imageId;
        public IntPtr tileInfo;
        public int imageSize;
        public IntPtr imageData;
        public int widthStep;
        public int BorderMode0;
        public int BorderMode1;
        public int BorderMode2;
        public int BorderMode3;
        public int BorderConst0;
        public int BorderConst1;
        public int BorderConst2;
        public int BorderConst3;
        public IntPtr imageDataOrigin;
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct _CvHistogram
    {
        public int type;
        public IntPtr bins;
        public fixed float thresh[32 * 2]; /* for uniform histograms */
        public IntPtr thresh2; /* for non-uniform histograms */
        public IntPtr mat; /* embedded matrix header for array histograms */
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct _CvKalman
    {
        public int MP;                     /* number of measurement vector dimensions */
        public int DP;                     /* number of state vector dimensions */
        public int CP;                     /* number of control vector dimensions */

        /* backward compatibility fields */
        public float* PosterState;         /* =state_pre->data.fl */
        public float* PriorState;          /* =state_post->data.fl */
        public float* DynamMatr;           /* =transition_matrix->data.fl */
        public float* MeasurementMatr;     /* =measurement_matrix->data.fl */
        public float* MNCovariance;        /* =measurement_noise_cov->data.fl */
        public float* PNCovariance;        /* =process_noise_cov->data.fl */
        public float* KalmGainMatr;        /* =gain->data.fl */
        public float* PriorErrorCovariance;/* =error_cov_pre->data.fl */
        public float* PosterErrorCovariance;/* =error_cov_post->data.fl */
        public float* Temp1;               /* temp1->data.fl */
        public float* Temp2;               /* temp2->data.fl */

        public IntPtr state_pre;           /* predicted state (x'(k)):
                                             x(k)=A*x(k-1)+B*u(k) */
        public IntPtr state_post;          /* corrected state (x(k)):
                                            x(k)=x'(k)+K(k)*(z(k)-H*x'(k)) */
        public IntPtr transition_matrix;   /* state transition matrix (A) */
        public IntPtr control_matrix;      /* control matrix (B)
                                            (it is not used if there is no control)*/
        public IntPtr measurement_matrix;  /* measurement matrix (H) */
        public IntPtr process_noise_cov;   /* process noise covariance matrix (Q) */
        public IntPtr measurement_noise_cov; /* measurement noise covariance matrix (R) */
        public IntPtr error_cov_pre;       /* priori error estimate covariance matrix (P'(k)):
                                             P'(k)=A*P(k-1)*At + Q)*/
        public IntPtr gain;                /* Kalman gain matrix (K(k)):
                                             K(k)=P'(k)*Ht*inv(H*P'(k)*Ht+R)*/
        public IntPtr error_cov_post;      /* posteriori error estimate covariance matrix (P(k)):
                                             P(k)=(I-K(k)*H)*P'(k) */
        public IntPtr temp1;               /* temporary matrices */
        public IntPtr temp2;
        public IntPtr temp3;
        public IntPtr temp4;
        public IntPtr temp5;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvBGStatModel
    {
        public int type; /*type of BG model*/
        public IntPtr release;
        public IntPtr update;
        public IntPtr background;   /*8UC3 reference background image*/
        public IntPtr foreground;   /*8UC1 foreground image*/
        public IntPtr layers;       /*8UC3 reference background image, can be null */
        public int layer_count;  /* can be zero */
        public IntPtr storage;      /*storage for foreground_regions*/
        public IntPtr foreground_regions; /*foreground object contours*/
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvSeq
    {
        public int flags; /* micsellaneous flags */
        public int header_size; /* size of sequence header */
        public IntPtr h_prev; /* previous sequence */
        public IntPtr h_next; /* next sequence */
        public IntPtr v_prev; /* 2nd previous sequence */
        public IntPtr v_next; /* 2nd next sequence */
        public int total; /* total number of elements */
        public int elem_size;/* size of sequence element in bytes */
        public IntPtr block_max;/* maximal bound of the last block */
        public IntPtr ptr; /* current write pointer */
        public int delta_elems; /* how many elements allocated when the sequence grows
                                   (sequence granularity) */
        public IntPtr storage; /* where the seq is stored */
        public IntPtr free_blocks; /* free blocks list */
        public IntPtr first;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvContour
    {
        public int flags; /* micsellaneous flags */
        public int header_size; /* size of sequence header */
        public IntPtr h_prev; /* previous sequence */
        public IntPtr h_next; /* next sequence */
        public IntPtr v_prev; /* 2nd previous sequence */
        public IntPtr v_next; /* 2nd next sequence */
        public int total; /* total number of elements */
        public int elem_size;/* size of sequence element in bytes */
        public IntPtr block_max;/* maximal bound of the last block */
        public IntPtr ptr; /* current write pointer */
        public int delta_elems; /* how many elements allocated when the sequence grows
                                   (sequence granularity) */
        public IntPtr storage; /* where the seq is stored */
        public IntPtr free_blocks; /* free blocks list */
        public IntPtr first;

        public CvRect rect;
        public int color;
        public int reserved0;
        public int reserved1;
        public int reserved2;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _CvSeqReader
    {
        public int header_size;
        public IntPtr seq;        /* sequence, beign read */
        public IntPtr block;      /* current block */
        public IntPtr ptr;        /* pointer to element be read next */
        public IntPtr block_min;  /* pointer to the beginning of block */
        public IntPtr block_max;  /* pointer to the end of block */
        public int delta_index;   /* = seq->first->start_index   */
        public IntPtr prev_elem;  /* pointer to previous element */
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _IplConvKernel
    {
        public int nCols;
        public int nRows;
        public int anchorX;
        public int anchorY;
        public IntPtr values;
        public int nShiftR;
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct _CvConDensation
    {
        public int MP;
        public int DP;
        public float* DynamMatr;       /* Matrix of the linear Dynamics system  */
        public float* State;           /* Vector of State                       */
        public int SamplesNum;         /* Number of the Samples                 */
        public float** flSamples;      /* arr of the Sample Vectors             */
        public float** flNewSamples;   /* temporary array of the Sample Vectors */
        public float* flConfidence;    /* Confidence for each Sample            */
        public float* flCumulative;    /* Cumulative confidence                 */
        public float* Temp;            /* Temporary vector                      */
        public float* RandomSample;    /* RandomVector to update sample set     */
        public IntPtr RandS;           /* Array of structures to generate random vectors */
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct _CvFont
    {
        byte* nameFont;		//Qt:nameFont
        CvScalar color;				//Qt:ColorFont -> cvScalar(blue_component, green_component, red\_component[, alpha_component])
        int font_face; 		//Qt: bool italic         /* =CV_FONT_* */
        int* ascii; 			/* font data and metrics */
        int* greek;
        int* cyrillic;
        float hscale, vscale;
        float shear; 			/* slope coefficient: 0 - normal, >0 - italic */
        int thickness; 		//Qt: weight               /* letters thickness */
        float dx; 			/* horizontal interval between letters */
        int line_type;		//Qt: PointSize
    }
}
