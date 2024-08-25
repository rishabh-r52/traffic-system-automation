import tensorflow as tf
import numpy as np
import cv2
from object_detection.utils import config_util
from object_detection.utils import visualization_utils as viz_utils
from object_detection.builders import model_builder

# Paths
pipeline_config = 'path/to/your/pipeline.config'
model_dir = 'path/to/your/model_directory'
output_directory = 'path/to/exported-model-directory'
label_map_path = 'path/to/your/label_map.pbtxt'
test_image_path = 'path/to/your/test_image.jpg'

# Load pipeline config and build a detection model
configs = config_util.get_configs_from_pipeline_file(pipeline_config)
model_config = configs['model']
detection_model = model_builder.build(model_config=model_config, is_training=False)

# Restore checkpoint
ckpt = tf.compat.v2.train.Checkpoint(model=detection_model)
ckpt.restore(os.path.join(output_directory, 'ckpt-0')).expect_partial()

def load_image_into_numpy_array(path):
    return np.array(cv2.imread(path))

# Load the label map
category_index = label_map_util.create_category_index_from_labelmap(label_map_path, use_display_name=True)

# Test on a single image
def run_inference_for_single_image(model, image):
    image = np.asarray(image)
    input_tensor = tf.convert_to_tensor(image)
    input_tensor = input_tensor[tf.newaxis, ...]

    # Run inference
    detections = model(input_tensor)

    # All outputs are batches tensors.
    # Convert to numpy arrays, and take index [0] to remove the batch dimension.
    num_detections = int(detections.pop('num_detections'))
    detections = {key: value[0, :num_detections].numpy() for key, value in detections.items()}
    detections['num_detections'] = num_detections

    # detection_classes should be ints.
    detections['detection_classes'] = detections['detection_classes'].astype(np.int64)

    return detections

def show_inference(model, image_path):
    # The input needs to be a tensor, convert it using `tf.convert_to_tensor`.
    image_np = load_image_into_numpy_array(image_path)

    # Actual detection.
    detections = run_inference_for_single_image(model, image_np)

    # Visualization of the results of a detection.
    viz_utils.visualize_boxes_and_labels_on_image_array(
        image_np,
        detections['detection_boxes'],
        detections['detection_classes'],
        detections['detection_scores'],
        category_index,
        use_normalized_coordinates=True,
        line_thickness=8)

    # Display output
    cv2.imshow('object_detection', cv2.resize(image_np, (800, 600)))
    cv2.waitKey(0)
    cv2.destroyAllWindows()

# Test the model on the test image
show_inference(detection_model, test_image_path)
