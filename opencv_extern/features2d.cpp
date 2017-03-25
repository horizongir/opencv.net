#include "extern.h"

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

CVEXTERN(void) cv_features2d_FeatureDetector_detect(cv::FeatureDetector *detector, cv::Mat *image, std::vector<cv::KeyPoint> *keypoints, CvArr *mask)
{
	detector->detect(*image, *keypoints, cv::cvarrToMat(mask));
}

CVEXTERN(void) cv_features2d_DescriptorExtractor_compute(cv::DescriptorExtractor *extractor, cv::Mat *image, std::vector<cv::KeyPoint> *keypoints, CvArr *descriptors)
{
	extractor->compute(*image, *keypoints, cv::cvarrToMat(descriptors));
}

CVEXTERN(int) cv_features2d_DescriptorExtractor_descriptorSize(cv::DescriptorExtractor *extractor)
{
	return extractor->descriptorSize();
}

CVEXTERN(int) cv_features2d_DescriptorExtractor_descriptorType(cv::DescriptorExtractor *extractor)
{
	return extractor->descriptorType();
}

CVEXTERN(void) cv_features2d_FAST(CvArr *image, std::vector<cv::KeyPoint> *keypoints, int threshold, bool nonmaxSupression)
{
	cv::FAST(cv::cvarrToMat(image), *keypoints, threshold, nonmaxSupression);
}

CVEXTERN(void) cv_features2d_FASTX(CvArr *image, std::vector<cv::KeyPoint> *keypoints, int threshold, bool nonmaxSuppression, int type)
{
	cv::FASTX(cv::cvarrToMat(image), *keypoints, threshold, nonmaxSuppression, type);
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
