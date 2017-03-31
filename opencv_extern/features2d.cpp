#include "extern.h"

/* KeyPoint class */

CVEXTERN(void) cv_features2d_KeyPoint_convert_vector_KeyPoint(std::vector<cv::KeyPoint> *keypoints, std::vector<cv::Point2f> *points2f, std::vector<int> *keypointIndexes)
{
	cv::KeyPoint::convert(*keypoints, *points2f, empty(keypointIndexes));
}

CVEXTERN(void) cv_features2d_KeyPoint_convert_vector_Point2f(std::vector<cv::Point2f> *points2f, std::vector<cv::KeyPoint> *keypoints, float size, float response, int octave, int class_id)
{
	cv::KeyPoint::convert(*points2f, *keypoints, size, response, octave, class_id);
}

CVEXTERN(float) cv_features2d_KeyPoint_overlap(cv::KeyPoint *kp1, cv::KeyPoint *kp2)
{
	return cv::KeyPoint::overlap(*kp1, *kp2);
}

CVEXTERN(void) cv_features2d_KeyPointsFilter_runByImageBorder(std::vector<cv::KeyPoint> *keypoints, CvSize imageSize, int borderSize)
{
	cv::KeyPointsFilter::runByImageBorder(*keypoints, cv::Size(imageSize), borderSize);
}

CVEXTERN(void) cv_features2d_KeyPointsFilter_runByKeypointSize(std::vector<cv::KeyPoint> *keypoints, float minSize, float maxSize)
{
	cv::KeyPointsFilter::runByKeypointSize(*keypoints, minSize, maxSize);
}

CVEXTERN(void) cv_features2d_KeyPointsFilter_runByPixelsMask(std::vector<cv::KeyPoint> *keypoints, CvArr *mask)
{
	cv::KeyPointsFilter::runByPixelsMask(*keypoints, cv::cvarrToMat(mask));
}

CVEXTERN(void) cv_features2d_KeyPointsFilter_removeDuplicated(std::vector<cv::KeyPoint> *keypoints)
{
	cv::KeyPointsFilter::removeDuplicated(*keypoints);
}

CVEXTERN(void) cv_features2d_KeyPointsFilter_retainBest(std::vector<cv::KeyPoint> *keypoints, int npoints)
{
	cv::KeyPointsFilter::retainBest(*keypoints, npoints);
}

/* FeatureDetector macro */

#define DETECTOR(type, name)\
CVEXTERN(void) cv_features2d_##name##_detect(##type## *detector, CvArr *image, std::vector<cv::KeyPoint> *keypoints, CvArr *mask)\
{\
	detector->detect(cv::cvarrToMat(image), *keypoints, cv::cvarrToMat(mask));\
}\
\

/* DescriptorExtractor macro */

#define EXTRACTOR(type, name)\
CVEXTERN(void) cv_features2d_##name##_compute(##type## *extractor, CvArr *image, std::vector<cv::KeyPoint> *keypoints, CvArr *descriptors)\
{\
	extractor->compute(cv::cvarrToMat(image), *keypoints, cv::cvarrToMat(descriptors));\
}\
\
CVEXTERN(int) cv_features2d_##name##_descriptorSize(##type## *extractor)\
{\
	return extractor->descriptorSize();\
}\
\
CVEXTERN(int) cv_features2d_##name##_descriptorType(##type## *extractor)\
{\
	return extractor->descriptorType();\
}\
\

/* BRISK class */

CVEXTERN(cv::BRISK*) cv_features2d_BRISK_new(int thresh, float octaves, float patternScale)
{
	return new cv::BRISK(thresh, octaves, patternScale);
}

DETECTOR(cv::BRISK, BRISK)
EXTRACTOR(cv::BRISK, BRISK)

CVEXTERN(void) cv_features2d_BRISK_delete(cv::BRISK *feature)
{
	delete feature;
}

/* ORB class */

CVEXTERN(cv::ORB*) cv_features2d_ORB_new(int nfeatures, float scaleFactor, int nlevels, int edgeThreshold, int firstLevel, int WTA_K, int scoreType, int patchSize)
{
	return new cv::ORB(nfeatures, scaleFactor, nlevels, edgeThreshold, firstLevel, WTA_K, scoreType, patchSize);
}

DETECTOR(cv::ORB, ORB)
EXTRACTOR(cv::ORB, ORB)

CVEXTERN(void) cv_features2d_ORB_delete(cv::ORB *feature)
{
	delete feature;
}

/* FAST */

CVEXTERN(void) cv_features2d_FAST(CvArr *image, std::vector<cv::KeyPoint> *keypoints, int threshold, bool nonmaxSupression)
{
	cv::FAST(cv::cvarrToMat(image), *keypoints, threshold, nonmaxSupression);
}

CVEXTERN(void) cv_features2d_FASTX(CvArr *image, std::vector<cv::KeyPoint> *keypoints, int threshold, bool nonmaxSuppression, int type)
{
	cv::FASTX(cv::cvarrToMat(image), *keypoints, threshold, nonmaxSuppression, type);
}

/* DescriptorMatcher macro */

#define MATCHER(type, name)\
CVEXTERN(void) cv_features2d_##name##_match(##type## *matcher, CvArr *queryDescriptors, CvArr *trainDescriptors, std::vector<cv::DMatch> *matches, CvArr *mask)\
{\
	matcher->match(cv::cvarrToMat(queryDescriptors), cv::cvarrToMat(trainDescriptors), *matches, cv::cvarrToMat(mask));\
}\
\

/* BFMatcher class */

CVEXTERN(cv::BFMatcher*) cv_features2d_BFMatcher_new(int normType, bool crossCheck)
{
	return new cv::BFMatcher(normType, crossCheck);
}

MATCHER(cv::BFMatcher, BFMatcher)

CVEXTERN(void) cv_features2d_BFMatcher_delete(cv::BFMatcher *matcher)
{
	delete matcher;
}

/* FlannBasedMatcher class */

CVEXTERN(cv::FlannBasedMatcher*) cv_features2d_FlannBasedMatcher_new()
{
	return new cv::FlannBasedMatcher();
}

MATCHER(cv::FlannBasedMatcher, FlannBasedMatcher)

CVEXTERN(void) cv_features2d_FlannBasedMatcher_delete(cv::FlannBasedMatcher *matcher)
{
	delete matcher;
}

/* Drawing functions */

CVEXTERN(void) cv_features2d_drawKeypoints(CvArr *image, std::vector<cv::KeyPoint> *keypoints, CvArr *outImage, CvScalar color, int flags)
{
	cv::drawKeypoints(cv::cvarrToMat(image), *keypoints, cv::cvarrToMat(outImage), color, flags);
}

CVEXTERN(void) cv_features2d_drawMatches(
	CvArr* img1, std::vector<cv::KeyPoint> *keypoints1,
	CvArr* img2, std::vector<cv::KeyPoint> *keypoints2,
	std::vector<cv::DMatch> *matches1to2, CvArr *outImg,
	CvScalar matchColor, CvScalar singlePointColor,
	std::vector<char> *matchesMask, int flags)
{
	cv::drawMatches(
		cv::cvarrToMat(img1), *keypoints1,
		cv::cvarrToMat(img2), *keypoints2,
		*matches1to2, cv::cvarrToMat(outImg),
		matchColor, singlePointColor,
		empty(matchesMask), flags);
}
