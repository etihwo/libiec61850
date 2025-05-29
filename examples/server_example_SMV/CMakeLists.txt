include_directories(
   .
)

set(server_example_SMV_SRCS
   server_example_SMV.c
   static_model.c
)

IF(MSVC)
set_source_files_properties(${server_example_SMV_SRCS}
                                       PROPERTIES LANGUAGE CXX)
ENDIF(MSVC)

add_executable(server_example_SMV
  ${server_example_SMV_SRCS}
)

target_link_libraries(server_example_SMV
    iec61850
)
