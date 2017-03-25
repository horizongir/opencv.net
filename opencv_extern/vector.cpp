#include "extern.h"

/* vector_iterator */

template<class T>
class vector_iterator
{
	typename std::vector<T>::const_iterator current;
	typename std::vector<T>::const_iterator end;
public:
	vector_iterator(const std::vector<T> &vector)
		: current(vector.begin()), end(vector.end()) { }

	T next() { return *current++; }
	bool hasNext() const { return current != end; }
};

/* vector_int */

CVEXTERN(std::vector<int>*) cv_vector_int_new()
{
	return new std::vector<int>;
}

CVEXTERN(std::vector<int>*) cv_vector_int_new_array(int *data, size_t length)
{
	return new std::vector<int>(data, data + length);
}

CVEXTERN(size_t) cv_vector_int_size(std::vector<int> *vector)
{
	return vector->size();
}

CVEXTERN(void) cv_vector_int_copy(std::vector<int> *vector, int *data)
{
	std::copy(vector->begin(), vector->end(), data);
}

CVEXTERN(vector_iterator<int>*) cv_vector_int_iterator_new(std::vector<int> *vector)
{
	return new vector_iterator<int>(*vector);
}

CVEXTERN(int) cv_vector_int_iterator_next(vector_iterator<int> *iterator)
{
	return iterator->next();
}

CVEXTERN(bool) cv_vector_int_iterator_hasNext(vector_iterator<int> *iterator)
{
	return iterator->hasNext();
}

CVEXTERN(void) cv_vector_int_iterator_delete(vector_iterator<int> *iterator)
{
	delete iterator;
}

CVEXTERN(void) cv_vector_int_delete(std::vector<int> *vector)
{
	delete vector;
}

/* vector_Point2f */

CVEXTERN(std::vector<cv::Point2f>*) cv_vector_Point2f_new()
{
	return new std::vector<cv::Point2f>;
}

CVEXTERN(std::vector<cv::Point2f>*) cv_vector_Point2f_new_array(cv::Point2f *data, size_t length)
{
	return new std::vector<cv::Point2f>(data, data + length);
}

CVEXTERN(size_t) cv_vector_Point2f_size(std::vector<cv::Point2f> *vector)
{
	return vector->size();
}

CVEXTERN(void) cv_vector_Point2f_copy(std::vector<cv::Point2f> *vector, cv::Point2f *data)
{
	std::copy(vector->begin(), vector->end(), data);
}

CVEXTERN(vector_iterator<cv::Point2f>*) cv_vector_Point2f_iterator_new(std::vector<cv::Point2f> *vector)
{
	return new vector_iterator<cv::Point2f>(*vector);
}

CVEXTERN(cv::Point2f) cv_vector_Point2f_iterator_next(vector_iterator<cv::Point2f> *iterator)
{
	return iterator->next();
}

CVEXTERN(bool) cv_vector_Point2f_iterator_hasNext(vector_iterator<cv::Point2f> *iterator)
{
	return iterator->hasNext();
}

CVEXTERN(void) cv_vector_Point2f_iterator_delete(vector_iterator<cv::Point2f> *iterator)
{
	delete iterator;
}

CVEXTERN(void) cv_vector_Point2f_delete(std::vector<cv::Point2f> *vector)
{
	delete vector;
}

/* vector_KeyPoint */

CVEXTERN(std::vector<cv::KeyPoint>*) cv_vector_KeyPoint_new()
{
	return new std::vector<cv::KeyPoint>;
}

CVEXTERN(std::vector<cv::KeyPoint>*) cv_vector_KeyPoint_new_array(cv::KeyPoint *data, size_t length)
{
	return new std::vector<cv::KeyPoint>(data, data + length);
}

CVEXTERN(size_t) cv_vector_KeyPoint_size(std::vector<cv::KeyPoint> *vector)
{
	return vector->size();
}

CVEXTERN(void) cv_vector_KeyPoint_copy(std::vector<cv::KeyPoint> *vector, cv::KeyPoint *data)
{
	std::copy(vector->begin(), vector->end(), data);
}

CVEXTERN(vector_iterator<cv::KeyPoint>*) cv_vector_KeyPoint_iterator_new(std::vector<cv::KeyPoint> *vector)
{
	return new vector_iterator<cv::KeyPoint>(*vector);
}

CVEXTERN(cv::KeyPoint) cv_vector_KeyPoint_iterator_next(vector_iterator<cv::KeyPoint> *iterator)
{
	return iterator->next();
}

CVEXTERN(bool) cv_vector_KeyPoint_iterator_hasNext(vector_iterator<cv::KeyPoint> *iterator)
{
	return iterator->hasNext();
}

CVEXTERN(void) cv_vector_KeyPoint_iterator_delete(vector_iterator<cv::KeyPoint> *iterator)
{
	delete iterator;
}

CVEXTERN(void) cv_vector_KeyPoint_delete(std::vector<cv::KeyPoint> *vector)
{
	delete vector;
}
