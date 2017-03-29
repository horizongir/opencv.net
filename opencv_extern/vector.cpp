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

/* vector macro */

#define VECTOR(type, name)\
CVEXTERN(std::vector<##type##>*) cv_vector_##name##_new()\
{\
	return new std::vector<##type##>;\
}\
\
CVEXTERN(std::vector<##type##>*) cv_vector_##name##_new_array(##type## *data, size_t length)\
{\
	return new std::vector<##type##>(data, data + length);\
}\
\
CVEXTERN(size_t) cv_vector_##name##_size(std::vector<##type##> *vector)\
{\
	return vector->size();\
}\
\
CVEXTERN(void) cv_vector_##name##_copy(std::vector<##type##> *vector, ##type## *data)\
{\
	std::copy(vector->begin(), vector->end(), data);\
}\
\
CVEXTERN(vector_iterator<##type##>*) cv_vector_##name##_iterator_new(std::vector<##type##> *vector)\
{\
	return new vector_iterator<##type##>(*vector);\
}\
\
CVEXTERN(##type##) cv_vector_##name##_iterator_next(vector_iterator<##type##> *iterator)\
{\
	return iterator->next();\
}\
\
CVEXTERN(bool) cv_vector_##name##_iterator_hasNext(vector_iterator<##type##> *iterator)\
{\
	return iterator->hasNext();\
}\
\
CVEXTERN(void) cv_vector_##name##_iterator_delete(vector_iterator<##type##> *iterator)\
{\
	delete iterator;\
}\
\
CVEXTERN(void) cv_vector_##name##_delete(std::vector<##type##> *vector)\
{\
	delete vector;\
}\
\

/* vector definitions */

VECTOR(int, int)
VECTOR(char, char)
VECTOR(cv::Point2f, Point2f)
VECTOR(cv::KeyPoint, KeyPoint)
VECTOR(cv::DMatch, DMatch)
